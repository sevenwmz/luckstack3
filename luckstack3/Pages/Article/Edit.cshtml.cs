using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Filters;
using _17bang.Pages.Repository;
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
        //public IList<Keyword> Keyword { set; get; }

        //public Article EditPublish { set; get; }

        //private ArticleRepository _repository { set; get; }



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

            //_repository = new ArticleRepository();
        }


        public void OnGet()
        {
            int pageId = Convert.ToInt32(Request.RouteValues["id"]);

            //Get edit article Id , Use later.
            int authorId = Convert.ToInt32(RouteData.Values["id"]);

            //Connection string 
            string connectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";
            using (DbConnection connection = new SqlConnection(connectionToDatabase))
            {
                #region Take AD and Series
                //Prepare for selectList
                AdOfArticle = new List<SelectListItem> { };
                SeriesOfSelect = new List<SelectListItem> { };
                //Add AD selectList
                using (DbCommand sqlCommandOfAD = new SqlCommand("Select ContentOfAd,Id From AD", (SqlConnection)connection))
                {
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
                }

                //Add Series selectList
                using (DbCommand sqlCommandOfSeries = new SqlCommand("Select Name,Id From Series", (SqlConnection)connection))
                {
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    //Take data of Serise from datebase
                    SqlDataReader readerOfSeries = (SqlDataReader)sqlCommandOfSeries.ExecuteReader();
                    if (readerOfSeries.HasRows)
                    {
                        while (readerOfSeries.Read())
                        {
                            SeriesOfSelect.Add(new SelectListItem { Text = readerOfSeries["Name"].ToString(), Value = readerOfSeries["Id"].ToString() });
                        }
                    }//else nothing
                    connection.Close();
                }
                #endregion

                #region Main function to get edit article
                //Take edit article from datebase,Prepare to edit.
                using (
                    DbCommand sqlCommandOfArticle = new SqlCommand(
                        "Select " +
                        "a.Title," +
                        "a.Content," +
                        "a.Summary," +
                        "k.[Name]," +

                        //Think about don't need here . But maybe other day will be use, keep here
                        //"s.[Name]," +

                        "ad.ContentOfAd," +
                        "ad.[Url] " +
                        "From KeywordToArticle ka " +
                        "Left join Article a " +
                        "On ka.ArticleNameId = a.Id " +
                        "Left join Keyword k " +
                        "On ka.KeywordId = k.Id " +

                        //Same as just reason
                        //"Left join Series s " +
                        //"On a.SeriesId = s.Id " +

                        "Left Join AD ad " +
                        "On a.AdId = ad.Id " +
                        $"Where a.Id = @ArticleId ", (SqlConnection)connection
                        )
                    )
                {
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    //For edit article id , get it from URL
                    DbParameter pArticleId = new SqlParameter("@ArticleId", 119/*authorId*/);
                    sqlCommandOfArticle.Parameters.Add(pArticleId);
                    SqlDataReader reader = (SqlDataReader)sqlCommandOfArticle.ExecuteReader();

                    //Amazeing everybody!!!  performance not problem.
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
            //EditPublish = ArticleRepository.GetId(pageId);
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            // If Summary is null ,take content in front of 255 char'.
            if (string.IsNullOrEmpty(Summary))
            {
                Summary = Content.PadRight(255);
            }

            //Connect Database
            string connectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";
            using (DbConnection connection = new SqlConnection(connectionToDatabase))
            {
                #region Conver Keywords perpare to save 
                //Get Keywords From Page,Prepare to Save
                Keyword = Keyword.Trim();
                IList<string> tempKeyworsFromPage = Keyword.Split(" ");

                #endregion

                connection.Open();

                #region DbParameters And parameter
                //For Article Title
                DbParameter pTitle = new SqlParameter("@Title", Title);
                //For Article Content
                DbParameter pContent = new SqlParameter("@Content", Content);
                //For Article Summary
                DbParameter pSummary = new SqlParameter("@Summary", Summary);
                //For Article SeriesId
                DbParameter pSeries = new SqlParameter("@SeriesId", Series);
                //Get edit article Id , Use later.
                int authorId = Convert.ToInt32(RouteData.Values["id"]);
                #endregion

                if (string.IsNullOrEmpty(WebSite))
                {
                    #region Save No Ad Article
                    //For No AD Article
                    using (
                        DbCommand sqlCommandOfArticle = new SqlCommand(
                            $@"Update Article 
                            Set 
                            Title = @Title ,
                            Content = @Content  ,
                            LatestUpdateTime = GETDATE(),
                            Summary = @Summary  ,
                            SeriesId = (Select Id From Series Where Id = @SeriesId)
                            Where Id = /*@ArticleId*/  N'{119}' ",
                        (SqlConnection)connection)
                        )
                    {
                        DbParameter pArticleId = new SqlParameter("@ArticleId", authorId);
                        //Save To Article Database
                        sqlCommandOfArticle.Parameters.AddRange(new DbParameter[] { pTitle, pContent,  pSummary, pSeries });
                        sqlCommandOfArticle.ExecuteNonQuery();
                    }

                    #endregion
                }
                else
                {
                    #region Save Ad
                    //For AD
                    using (DbCommand sqlCommandOfAD = new SqlCommand(
                            $"Insert AD(ContentOfAd,Url) " +
                            $"Values(@ContentOfAd,@WebSite)",
                            (SqlConnection)connection))
                    {
                        //For Ad ContentOfAd 
                        DbParameter pContentOfAd = new SqlParameter("@ContentOfAd", ContentOfAD);
                        //For Ad WebSite
                        DbParameter pWebSite = new SqlParameter("@WebSite", WebSite);
                        //Save To Datebase
                        sqlCommandOfAD.Parameters.AddRange(new DbParameter[] { pContentOfAd, pWebSite });
                        sqlCommandOfAD.ExecuteNonQuery();
                    }
                    #endregion

                    #region Save Has AD Article
                    //Has AD Article
                    using (
                        DbCommand sqlCommandOfArticle = new SqlCommand(
                            @"Update Article 
                            Set
                            Title = N'123' ,
                            Content =  N'123',
                            LatestUpdateTime = GETDATE(),
                            Summary = N'123' ,
                            AdId = (Select Id From AD Where ContentOfAd = @ContentOfAd),
                            SeriesId = (Select Id From Series Where Id = @SeriesId) ",
                            (SqlConnection)connection)
                        )
                    {
                        //Add ADId in Article
                        DbParameter pContentOfAd = new SqlParameter("@ContentOfAd", ContentOfAD);
                        sqlCommandOfArticle.Parameters.AddRange(new DbParameter[] { pTitle, pContent, pSummary, pContentOfAd, pSeries });
                    }
                    #endregion
                }

                #region Save Of Keyword
                int getArticleId = Convert.ToInt32(Request.RouteValues["id"]);
                for (int i = 0; i < tempKeyworsFromPage.Count; i++)
                {
                    //Prepare Parameter
                    DbParameter pKeywordPage = new SqlParameter("@KeywordPage", tempKeyworsFromPage[i]);
                    DbParameter pArticleId = new SqlParameter("@ArticleId", getArticleId);

                    using (
                        DbCommand sqlCommandOfKeywords = new SqlCommand(
                            //Delete before n:n relation table data
                            $"Delete KeywordToArticle where ArticleNameId = /*@ArticleId*/ N'{119}' " +

                            //Check Keyword exist in Database
                            $"IF @KeywordPage In (Select [name] From Keyword Where[name] = @KeywordPage ) " +
                            $"Begin " +
                            //Add To KeywordToArticle
                            $"Insert KeywordToArticle(ArticleNameId, KeywordId) " +
                            $"Values(" +
                            $"(Select Id From Article Where Id = /*@ArticleId*/ N'{119}' " +

                            //Use too much resoures ,But open check will be precisely
                            //$"And SUBSTRING(Content,0,25) = SUBSTRING(N'{Content}',0,25) " +

                            $"And AuthorId = (Select Id from [User] Where UserName = N'{UserInfo.NickName}')), " +

                            $"(Select Id From Keyword Where[Name] = @KeywordPage)) " +
                            $"Update Keyword Set Used += 1 Where [Name] = @KeywordPage " +
                            $"End " +
                            //
                            //If this Keyword never appear ,add to keyword datebase,at same time add to n:n relation table
                            //
                            $"ELSE " +
                            $"Insert Keyword([Name],Used) Values(@KeywordPage,0) " +
                            $"Insert KeywordToArticle(ArticleNameId, KeywordId) " +
                            $"Values(" +
                            $"(Select Id From Article Where Id = /*@ArticleId*/ N'{119}' ), " +
                            //For Scend KeywordToArticle parameter [KeywordId]
                            $"(Select Id From Keyword Where[Name] = @KeywordPage)) ", (SqlConnection)connection
                            )
                        )
                    {
                        sqlCommandOfKeywords.Parameters.AddRange(new DbParameter[] { pArticleId, pKeywordPage });
                        sqlCommandOfKeywords.ExecuteNonQuery();
                    }
                }

                #endregion

            }
            //Article.ChangeArticleContent(EditPublish);
            //_repository.Save(EditPublish);



        }
    }

}