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
    public class _ExcellentArticle : ViewComponent
    {
        private ArticleRepository _repository;
        public IList<Article> articles { set; get; }
        public _ExcellentArticle()
        {
            _repository = new ArticleRepository();
        }

        public IViewComponentResult Invoke(int max)
        {
            articles = _repository.Get().Take(max).ToList();

            return View(articles);
        }
    }
}