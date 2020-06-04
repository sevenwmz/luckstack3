using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using _17bang.Pages.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace _17bang
{
    //[NeedLogOn(role: "文章发布")]
    public class NewOfArticleModel : PageModel
    {

        #region BindPropretity And Filed
        [Required(ErrorMessage = "* 标题不能为空")]
        [BindProperty]
        public string Title { set; get; }

        [Required(ErrorMessage = "* 内容不能为空")]
        [BindProperty]
        public string Content { set; get; }

        [Required(ErrorMessage = "系列不能为空")]
        [BindProperty]
        public string Series { set; get; }
        [BindProperty]
        public string Summary { set; get; }
        [BindProperty]
        public string Ad { set; get; }
        [BindProperty]
        public string ContentOfAd { set; get; }
        [BindProperty]
        public string WebSite { set; get; }
        [BindProperty]
        public string Keywords { set; get; }

        public User UserInfo { set; get; }
        //public IList<Keyword> Keyword { set; get; }
        //public Article NewArticle { set; get; }

        private ArticleRepository _repository { set; get; }

        public IList<SelectListItem> AdOfArticle { set; get; }

        public IList<SelectListItem> SeriesOfSelect { set; get; }

        private DBHelper _support;
        #endregion


        public NewOfArticleModel()
        {
            UserInfo = new User
            {
                NickName = "wpzwpz",
                Level = "⑩",
                Gender = "男",
                Birthday = "1981 年 4 月 ",
                Constellation = " 金牛座",
                SelfIntroduction = "十年磨一剑，专注于ASP.NET网站开发"
            };
            _repository = new ArticleRepository();
        }

        public void OnGet()
        {
            //Start connect database get selectList of AD and Series
            string connectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";
            using (DbConnection connection = new SqlConnection(connectionToDatabase))
            {
                string adOfArticleCmd = "Select ContentOfAd,Id From AD";
                string adOfArticleText = "ContentOfAd";
                string adOfArticleValue = "Id";
                AdOfArticle = _repository.GetSelectList(adOfArticleCmd, adOfArticleText, adOfArticleValue, connection);

                string seriesOfSelectCmd = "Select Name,Id From Series";
                string seriesOfSelectText = "Name";
                string seriesOfSelectValue = "Id";
                SeriesOfSelect = _repository.GetSelectList(seriesOfSelectCmd, seriesOfSelectText, seriesOfSelectValue, connection);
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Article/New");
            }

            // If Summary is null ,take content in front of 255 char'.
            if (string.IsNullOrEmpty(Summary))
            {
                Summary = Content.PadRight(255).Substring(0, 255).Trim();
            }
            else
            {
                Summary = Summary.Trim();
                if (Summary.Length > 255)
                {
                    Summary = Summary.Substring(0, 255);
                }//else nothing.
            }

            using (DbConnection connection = _support.Connection)
            {
                int? adId = null;
                connection.Open();

                if (!string.IsNullOrEmpty(WebSite))
                {
                    string cmd = @"Insert AD(ContentOfAd,Url) Values(@ContentOfAd,@WebSite) Set @NewId = @@Identity ";
                    adId = _support.ExcuteNonQuery(
                        connection, cmd, new SqlParameter[]
                        {
                        new SqlParameter("@ContentOfAd", ContentOfAd),
                        new SqlParameter("@WebSite", WebSite)
                        });
                }

                #region Save Article
                string articleCmdString = 
                    @"Insert Article (Title,Content,PublishTime,AuthorId,Summary,ADId,SeriesId) 
                         Values(@Title,@Content,GetDate(),(Select u.Id From[User]u Where u.UserName = @Author),@Summary),
                        (Select Id From AD Where ContentOfAd = @NewId 
                        (Select Id From Series Where Name = @SeriesId)";
                _support.ExcuteNonQuery(connection, articleCmdString, new SqlParameter[] {
                    new SqlParameter("@Title", Title),
                    new SqlParameter("@Content", Content),
                    new SqlParameter("@Author", UserInfo.NickName),
                    new SqlParameter("@Summary", Summary),
                    new SqlParameter("@SeriesId", Series),
                    new SqlParameter("@NewId", adId)
                });
                #endregion

                #region Save Of Keyword
                if (!string.IsNullOrEmpty(Keywords))
                {
                    IList<string> keywords = Keywords.Trim().Split(" ");
                    for (int i = 0; i < keywords.Count; i++)
                    {
                        int keywordsId = _repository.GetKeywordsId(keywords[i]);
                        _repository.PlusUsedKeyword(keywordsId);
                        int articleId = _repository.GetArticleId(Title);
                        _repository.AttachKeyword(articleId, keywordsId);

                        #region Old Filed Function
                        //using (
                        //DbCommand sqlCommandOfKeywords = new SqlCommand(
                        //    //Check Keyword exist in Database
                        //    $"IF N'{keywords[i]}' In (Select [name] From Keyword Where[name] = N'{keywords[i]}') " +
                        //    $"Begin " +
                        //    //Add To KeywordToArticle
                        //    $"Insert KeywordToArticle(ArticleNameId, KeywordId) " +
                        //    $"Values(" +
                        //    $"(Select Id From Article Where Title = @KTitle " +

                        //    //Use too much resoures ,But open check will be precisely
                        //    //$"And SUBSTRING(Content,0,25) = SUBSTRING(N'{Content}',0,25) " +

                        //    $"And AuthorId = (Select Id from [User] Where UserName = N'{UserInfo.NickName}')), " +

                        //    $"(Select Id From Keyword Where[Name] = @KeywordPage)) " +
                        //    $"Update Keyword Set Used += 1 Where [Name] = @KeywordPage " +
                        //    $"End " +
                        //    //
                        //    //If this Keyword never appear ,add to keyword datebase,at same time add to n:n relation table
                        //    //
                        //    $"ELSE " +
                        //    $"Insert Keyword([Name],Used) Values(@KeywordPage,0) " +
                        //    $"Insert KeywordToArticle(ArticleNameId, KeywordId) " +
                        //    $"Values(" +
                        //    $"(Select Id From Article Where Title = @KTitle " +

                        //    //Use too much resoures ,But open check will be precisely
                        //    //$"And SUBSTRING(Content,0,25) = SUBSTRING(N'{Content}',0,25) " +

                        //    $"And AuthorId = (Select Id from [User] Where UserName = N'{UserInfo.NickName}')), " +
                        //    //For Scend KeywordToArticle parameter [KeywordId]
                        //    $"(Select Id From Keyword Where[Name] = @KeywordPage)) ", (SqlConnection)connection
                        //    )
                        //)
                        //        {
                        //            sqlCommandOfKeywords.Parameters.AddRange(new DbParameter[] { new SqlParameter("@KTitle", Title), new SqlParameter("@KeywordPage", keywords[i]) });
                        //            sqlCommandOfKeywords.ExecuteNonQuery();
                        //        }
                        //    }
                        //}//else nothing
                        #endregion
                    }
                }
                #endregion

            }

            return Redirect("/Article");


        }
    }
}

