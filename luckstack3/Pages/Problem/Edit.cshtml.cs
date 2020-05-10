using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Filters;
using _17bang.Pages.Repository;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    [NeedLogOn(role:"登录用户")]
    [BindProperties]
    public class EditOfProblemModel : PageModel
    {
        public Problem Problems { set; get; }

        private ProblemRepository _problemRepository;



        public string NameofSerch { set; get; }

        public int RewardMoney { set; get; }

        private KeywordRepository _keyword;

        public IList<Keyword> Keywords { set; get; }


        public EditOfProblemModel()
        {
            _keyword = new KeywordRepository();
            _problemRepository = new ProblemRepository();
        }

        public void OnGet()
        {
            Keywords = _keyword.GetKeywords();

            int pageId = Convert.ToInt32(Request.RouteValues["id"]);

            Problems= ProblemRepository.GetId(pageId);
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            ///利用Repository，完成内容（求助/文章/意见建议）的
            ///修改：注意通过id修改正确的内容
            ///
            Problem.ChangeProblemContent(Problems);

            _problemRepository.Save(Problems);



        }

    }

}