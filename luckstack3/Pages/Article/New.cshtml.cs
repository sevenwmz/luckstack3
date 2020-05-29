using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Filters;
using _17bang.Pages.Repository;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace _17bang
{
    [NeedLogOn(role:"文章发布")]
    public class NewOfArticleModel : PageModel
    {

        #region BindPropretity
        [BindProperty]
        public string Title { set; get; }
        [BindProperty]
        public string Content { set; get; }

        [Required(ErrorMessage = "系列不能为空")]
        public string Series { set; get; }
        [BindProperty] 
        public string Summary { set; get; }
        public string Ad { set; get; }
        public string ContentOfAd { set; get; }
        public string WebSite { set; get; }
        #endregion

        public User UserInfo { set; get; }
        public IList<Keyword> Keyword { set; get; }
        //public Article NewArticle { set; get; }

        private ArticleRepository _repository { set; get; }

        public IList<SelectListItem> AdOfArticle { set; get; }



        public IList<SelectListItem> SeriesOfSelect { get; } =
         new List<SelectListItem>
         {
                new SelectListItem{Text= "默认分类",Value= "1" },
                new SelectListItem{Text= "讲课这些天",Value= "2" },
                new SelectListItem{Text= "ASP.NET",Value= "3" },
                new SelectListItem{Text= "Razor",Value= "4" },
                new SelectListItem{Text= "CSharp",Value= "5" },
                new SelectListItem{Text= "折腾",Value= "6" },
                new SelectListItem{Text= "空系列",Value= "6" },
         };
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
            Keyword = new List<Keyword>
            {
                new Keyword{Name = "安装" },
                new Keyword{Name = "ASP.NET" },
                new Keyword{Name = "SQL" }
            };
            AdOfArticle = new List<SelectListItem>
            {
                new SelectListItem{Text= "----- 使用新的广告 -----",Value= "1" },
                new SelectListItem{Text= "微商宣传广告语 日加1000精准",Value= "2" },
                new SelectListItem{Text= "如果你听了一课之后发现不喜欢这门课程，那你可以要求退回你的学费，但必须用法语说。",Value= "3" },
                new SelectListItem{Text= "煮酒论英雄才子赢天下",Value= "4" },
            };
            _repository = new ArticleRepository();
        }



        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Article/New");
            }
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


            string connectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";
            using (DbConnection connection = new SqlConnection(connectionToDatabase))
            {
                connection.Open();
                DbCommand sqlCommand = new SqlCommand(
                    $"Insert Article(Title,Content,PublishTime,AuthorId) Values(@Title,@Content,GetDate()," +
                    $"(Select u.Id From[User]u Where u.UserName = @Author))"
                    );

                //For Article Title
                DbParameter pTitle = new SqlParameter("@Title",Title);

                //For Article Content
                DbParameter pContent = new SqlParameter("@Content", Content);
                
                //For Article Author
                DbParameter pAuthor = new SqlParameter("@Author", UserInfo.NickName);

                sqlCommand.Parameters.AddRange( new DbParameter[] { pTitle, pContent, pAuthor });


                sqlCommand.Connection = connection;
                sqlCommand.ExecuteNonQuery();
            }

            return Redirect("/Article");
        }
    }

}