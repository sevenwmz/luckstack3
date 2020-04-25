using System;
using System.Collections.Generic;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _17bang.Repository;

namespace _17bang
{
    public class NewModel : PageModel
    {
        public string Title { set; get; }

        public string Recommend { set; get; }

        public string NameofSerch { set; get; }

        public int RewardMoney { set; get; }

        public string SelfKeywords { set; get; }
        public IList<Keyword> Keywords { set; get; }
        private KeywordRepository _keyword;
        public NewModel()
        {
            _keyword = new KeywordRepository();
        }

        public void OnGet()
        {
            Keywords = _keyword.GetKeywords();
        }
    }
}