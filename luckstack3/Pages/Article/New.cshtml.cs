using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using _17bang.Pages.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System;
using _17bang.Repository;

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

        private ArticleRepository _repository { set; get; }

        public IList<SelectListItem> AdOfArticle { set; get; }

        public IList<SelectListItem> SeriesOfSelect { set; get; }
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
            IList<Ad> ads = new AdRepository().Get();
            IList<Series> series = new SeriesRepository().Get();
            AdOfArticle = new List<SelectListItem> { };
            SeriesOfSelect = new List<SelectListItem> { };
            foreach (var item in ads)
            {
                AdOfArticle.Add(new SelectListItem { Text = item.AdName, Value = item.Id.ToString() });
            }
            foreach (var item in series)
            {
                SeriesOfSelect.Add(new SelectListItem { Text = item.SeriesName, Value = item.Id.ToString() });
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Article");
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

            //Save article info to database
            using (DbConnection connection = new DBHelper().Connection)
            {
                object adId = DBNull.Value;
                connection.Open();
                #region Save Ad
                if (!string.IsNullOrEmpty(WebSite))
                {
                    string cmd = @"Insert AD(ContentOfAd,Url) Values(@ContentOfAd,@WebSite)";
                    adId = new DBHelper().Insert(
                        connection, cmd, new SqlParameter[]
                        {
                        new SqlParameter("@ContentOfAd", ContentOfAd),
                        new SqlParameter("@WebSite", WebSite),
                        });
                }//else nothing
                #endregion

                #region Save Article
                string articleCmdString = 
                    @"Insert Article (Title,Content,PublishTime,AuthorId,Summary,ADId,SeriesId) 
                         Values(@Title,@Content,GetDate(),(Select u.Id From [User] u Where u.UserName = @Author),@Summary,
                        (Select Id From AD Where Id = @NewId ),
                        (Select Id From Series Where Name = @SeriesId))";
                new DBHelper().ExcuteNonQuery(articleCmdString, connection, new SqlParameter[] {
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
                    KeywordRepository keywordRepository = new KeywordRepository();
                    IList<string> keywords = Keywords.Trim().Split(" ");
                    for (int i = 0; i < keywords.Count; i++)
                    {
                        if (string.IsNullOrWhiteSpace(keywords[i]))
                        {
                            continue;
                        }
                        int keywordsId = keywordRepository.GetKeywordsId(keywords[i]);
                        keywordRepository.PlusUsedKeyword(keywordsId);
                        int articleId = _repository.GetArticleId(Title);
                        keywordRepository.AttachKeyword(articleId, keywordsId);
                    }
                }
                #endregion
            }
            return Redirect("/Article");
        }
    }
}

