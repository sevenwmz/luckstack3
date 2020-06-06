using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Filters;
using _17bang.Pages.Repository;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _17bang
{
    //[NeedLogOn(role:"文章发布")]
    //[BindProperties]
    public class EditModel : PageModel
    {
        #region Filed of Edit
        //For edit article title
        [BindProperty]
        public string Title { set; get; }
        //For edit article content
        [BindProperty]
        public string Content { set; get; }
        //For edit article series
        [BindProperty]
        public string Series { set; get; }
        //For edit article keyword
        [BindProperty]
        public string Keyword { set; get; }
        //For edit article summary
        [BindProperty]
        public string Summary { set; get; }
        //For edit article AD
        [BindProperty]
        public string AD { set; get; }
        //For edit article contentOfAD
        [BindProperty]
        public string ContentOfAD { set; get; }
        //For edit article website
        [BindProperty]
        public string WebSite { set; get; }
        //For edit article ADSelectList
        [BindProperty]
        public IList<SelectListItem> AdOfArticle { set; get; }
        //For edit article seriesSelectList
        [BindProperty]
        public IList<SelectListItem> SeriesOfSelect { get; set; }
        #endregion

        public User UserInfo { set; get; }

        private ArticleRepository _repository { set; get; }

        public EditModel()
        {
            UserInfo = new User
            {
                NickName = "wpz",
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
            int pageId = Convert.ToInt32(Request.RouteValues["id"]);
            int AritcleId = Convert.ToInt32(RouteData.Values["id"]);
            #region  Take Ad and Series
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
            #endregion

            #region Take need edit article from database
            using (DbConnection connection = new DBHelper().Connection)
            {
                string cmd = @"Select a.Title,a.Content,a.Summary,k.[Name],ad.ContentOfAd,ad.[Url] 
                            From KeywordToArticle ka  
                            Left join Article a 
                            On ka.ArticleNameId = a.Id 
                            Left join Keyword k 
                            On ka.KeywordId = k.Id 
                            Left Join AD ad 
                            On a.AdId = ad.Id 
                            Where a.Id = @ArticleId ";

                DbDataReader reader = new DBHelper().ExcuteReader(cmd, connection, new SqlParameter[] { new SqlParameter("@ArticleId", 123) });
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Title = reader["Title"].ToString();
                        Content = reader["Content"].ToString();
                        Summary = reader["Summary"].ToString();
                        ContentOfAD = reader["ContentOfAd"].ToString();
                        WebSite = reader["Url"].ToString();
                        Keyword = Keyword + reader["name"].ToString() + " ";
                    }
                }
            }

            #endregion
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

            #region Update Ad
            if (!string.IsNullOrEmpty(WebSite))
            {
                string adCmdText = "Update AD Set ContentOfAd = @ContentOfAd,Url = @WebSite";
                new AdRepository().SaveEditAd(adCmdText, new SqlParameter[]
                {
                    new SqlParameter("@ContentOfAd", ContentOfAD),new SqlParameter("@WebSite", WebSite)
                });
            }
            #endregion

            #region Update Article
            int AritcleId = Convert.ToInt32(RouteData.Values["id"]);
            string cmdText =
                @"Update Article Set Title = @Title,Content = @Content,LatestUpdateTime = GETDATE(),Summary = @Summary,
                    AdId = (Select Id from AD Where Id = @NewId),SeriesId = (Select Id from Series Where Id = @SeriesId) 
                    Where Id = @ArticleId";

            _repository.SaveEditArticle(cmdText, new SqlParameter[]
            {
                new SqlParameter("@Title", Title),
                new SqlParameter("@Content", Content),
                new SqlParameter("@Summary", Summary),
                new SqlParameter("@ArticleId",AritcleId),
                new SqlParameter("@SeriesId", Series),
                new SqlParameter("@NewId", AD)
            });
            #endregion

            #region Save Of Keyword
            int getArticleId = Convert.ToInt32(Request.RouteValues["id"]);
            new KeywordRepository().UpdateKeywords(Keyword, getArticleId);
            #endregion

            return Redirect("/Article");
        }

    }
}

