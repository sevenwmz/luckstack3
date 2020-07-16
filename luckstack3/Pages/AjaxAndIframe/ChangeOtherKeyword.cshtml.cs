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
    [IgnoreAntiforgeryToken]
    public class ChangeOtherKeywordModel : PageModel
    {

        public IList<Keyword> Keywords { set; get; }
        private KeywordRepository _repoisitory;


        public ChangeOtherKeywordModel()
        {
            _repoisitory = new KeywordRepository();
        }

        public void OnGet()
        {
            Keywords = _repoisitory.Get().Take(5).ToList();
        }
        public void OnPost(int max)
        {
            Keywords = _repoisitory.Get().Take(max).ToList();
        }
    }
}