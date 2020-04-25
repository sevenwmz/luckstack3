using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace luckstack3
{
    public class Write : PageModel
    {

        public bool? IsMale { set; get; }

        public Constellation Constellation { set; get; }

        public string Other { set; get; }

        public IList<Keyword> Keywords { set; get; }
        private KeywordRepository _keyword;
        public Write()
        {
            _keyword = new KeywordRepository();
        }
        public void OnGet()
        {
            Keywords = _keyword.GetKeywords();
        }
    }


    public enum Constellation
    {
        白羊座,
        金牛座,
        双子座,
        巨蟹座,
        狮子座,
        处女座,
        天秤座,
        天蝎座,
        射手座,
        摩羯座,
        水瓶座,
        双鱼座,
    }
}