using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class _KeywordsModel : ViewComponent
    {
        public IList<Keyword> Keyword { set; get; }
        private KeywordRepository _repoisitory;

        public _KeywordsModel()
        {
            _repoisitory = new KeywordRepository();
        }

        public IViewComponentResult Invoke(int max)
        {
            Keyword = _repoisitory.Get();
            Keyword.Take(max).ToList();

            return View();
        }
    }
}