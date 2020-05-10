using System;
using System.Collections.Generic;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _17bang.Repository;
using _17bang.Pages.Repository;
using _17bang.Filters;

namespace _17bang
{   
    [NeedLogOn(role: "登录用户 ")]
    [BindProperties]
    public class NewModel : PageModel
    {
        public Problem Problems { set; get; }

        private ProblemRepository _problemRepository;
        private KeywordRepository _keyword;

        public NewModel()
        {
            _problemRepository = new ProblemRepository();
            _keyword = new KeywordRepository();
        }


        public string NameofSerch { set; get; }

        public int RewardMoney { set; get; }


        public IList<Keyword> Keywords { set; get; }


        public void OnGet()
        {
            Keywords = _keyword.GetKeywords();
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            ///利用Repository，完成内容（求助/文章/意见建议）的
            ///新建
            _problemRepository.Save(Problems);


        }

    }

}