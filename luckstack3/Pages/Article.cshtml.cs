using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class AreicleModel : PageModel
    {
        public IList<Article> Items { set; get; }
        public int SumOfArticle { set; get; }

        private Article _article;
        public AreicleModel()
        {
            _article = new Article();
        }
        public void OnGet()
        {
            int pageIndex = Convert.ToInt32(Request.Query["pageIndex"]);
            int pageSize = 2;

            SumOfArticle = _article.GetSum();
            Items = _article.GetPaged(pageSize, pageIndex);
        }




    }
}