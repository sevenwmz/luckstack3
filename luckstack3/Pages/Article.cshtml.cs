using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class AreicleModel : PageModel
    {
        /// <summary>
        /// 一个集合
        /// </summary>
        public IList<Article> Items { set; get; }
        public int SumOfArticle { set; get; }

        private ArticleRepository _article;
        public AreicleModel()
        {
            _article = new ArticleRepository();
        }
        public void OnGet()
        {
            int pageIndex = Convert.ToInt32(Request.RouteValues["id"]);
            int pageSize = 2;

            SumOfArticle = _article.GetSum();
            Items = _article.GetPaged(pageSize, pageIndex);
        }




    }
}