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
        //new List<SelectListItem>
        //{
        //       new SelectListItem{Text= "默认分类",Value= "1" },
        //       new SelectListItem{Text= "讲课这些天",Value= "2" },
        //       new SelectListItem{Text= "ASP.NET",Value= "3" },
        //       new SelectListItem{Text= "Razor",Value= "4" },
        //       new SelectListItem{Text= "CSharp",Value= "5" },
        //       new SelectListItem{Text= "折腾",Value= "6" },
        //       new SelectListItem{Text= "空系列",Value= "6" },
        //};
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
            //Keyword = new List<Keyword>
            //{
            //    new Keyword{Name = "安装" },
            //    new Keyword{Name = "ASP.NET" },
            //    new Keyword{Name = "SQL" }
            //};
            //AdOfArticle = new List<SelectListItem>
            //{
            //    new SelectListItem{Text= "----- 使用新的广告 -----",Value= "1" },
            //    new SelectListItem{Text= "微商宣传广告语 日加1000精准",Value= "2" },
            //    new SelectListItem{Text= "如果你听了一课之后发现不喜欢这门课程，那你可以要求退回你的学费，但必须用法语说。",Value= "3" },
            //    new SelectListItem{Text= "煮酒论英雄才子赢天下",Value= "4" },
            //};
            _repository = new ArticleRepository();
        }


        public void OnGet()
        {
            //Prepare for selectList
            AdOfArticle = new List<SelectListItem> { };
            SeriesOfSelect = new List<SelectListItem> { };

            //Start connect database get selectList of AD and Series
            string connectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";
            using (DbConnection connection = new SqlConnection(connectionToDatabase))
            {
                DbCommand sqlCommandOfAD = new SqlCommand("Select ContentOfAd,Id From AD", (SqlConnection)connection);
                DbCommand sqlCommandOfSeries = new SqlCommand("Select Name,Id From Series", (SqlConnection)connection);

                connection.Open();

                //Take data of AD from datebase
                SqlDataReader readerOfAD = (SqlDataReader)sqlCommandOfAD.ExecuteReader();
                if (readerOfAD.HasRows)
                {
                    while (readerOfAD.Read())
                    {
                        AdOfArticle.Add(new SelectListItem { Text = readerOfAD["ContentOfAd"].ToString(), Value = readerOfAD["Id"].ToString() });
                    }
                }//else nothing

                connection.Close();
                connection.Open();

                //Take data of Serise from datebase
                SqlDataReader readerOfSeries = (SqlDataReader)sqlCommandOfSeries.ExecuteReader();
                if (readerOfSeries.HasRows)
                {
                    while (readerOfSeries.Read())
                    {
                        SeriesOfSelect.Add(new SelectListItem { Text = readerOfSeries["Name"].ToString(), Value = readerOfSeries["Id"].ToString() });
                    }
                }//else nothing
            }

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Article/New");
            }

            #region Old Skill ADO.NET Of Connect Database
            //_repository.Save(NewArticle);

            //string connectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";
            //using (DbConnection connection = new SqlConnection(connectionToDatabase))
            //{
            //    connection.Open();
            //    DbCommand sqlCommand = new SqlCommand(
            //        $"Insert Article(Title,Content,PublishTime,AuthorId) Values(N'{Title}',N'{Content}',GetDate()," +
            //        $"(Select u.Id From[User]u Where u.UserName = N'{UserInfo.NickName}'))"
            //        );
            //    sqlCommand.Connection = connection;
            //    sqlCommand.ExecuteNonQuery();

            //    return Redirect("/Article");
            //}
            #endregion

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

            //Connect Database
            string connectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";
            using (DbConnection connection = new SqlConnection(connectionToDatabase))
            {
                int? adId = null;
                connection.Open();

                if (!string.IsNullOrEmpty(WebSite))
                {
                    #region Save No Ad Article
                    //For AD
                    using (DbCommand sqlCommandOfAD = new SqlCommand(
                            $"Insert AD(ContentOfAd,Url) " +
                            $"Values(@ContentOfAd,@WebSite)" +
                            $"{adId} = Select Id From AD Where Url = @WebSite ",
                            (SqlConnection)connection))
                    {
                        //Save To Datebase
                        sqlCommandOfAD.Parameters.AddRange(new DbParameter[] { new SqlParameter("@ContentOfAd", ContentOfAd), new SqlParameter("@WebSite", WebSite) });
                        sqlCommandOfAD.ExecuteNonQuery();
                    }
                    #endregion
                }

                #region Save Article
                //Has AD Article
                using (
                    DbCommand sqlCommandOfArticle = new SqlCommand(
                        $"Insert Article (Title,Content,PublishTime,AuthorId,Summary,ADId,SeriesId) " +
                        $"Values(@Title,@Content,GetDate(),(Select u.Id From[User]u Where u.UserName = @Author),@Summary)," +
                        $"(Select Id From AD Where ContentOfAd = {adId} ," +
                        $"(Select Id From Series Where Name = @SeriesId)",
                        (SqlConnection)connection)
                    )
                {
                    sqlCommandOfArticle.Parameters.AddRange(new DbParameter[] {
                            new SqlParameter("@Title", Title),
                            new SqlParameter("@Content", Content),
                            new SqlParameter("@Author", UserInfo.NickName),
                            new SqlParameter("@Summary", Summary),
                            new SqlParameter("@SeriesId", Series)
                        });
                    sqlCommandOfArticle.ExecuteNonQuery();
                }
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

