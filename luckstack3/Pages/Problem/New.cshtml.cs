using System;
using System.Collections.Generic;
using Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _17bang.Repository;
using _17bang.Pages.Repository;

namespace _17bang
{
    public class NewModel : PageModel
    {
        public Problem Problems { set; get; }

        private ProblemRepository _problemRepository;
        public NewModel()
        {
            _problemRepository = new ProblemRepository();

        }


        public string NameofSerch { set; get; }

        public int RewardMoney { set; get; }

        private KeywordRepository _keyword;

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
            ///修改：注意通过id修改正确的内容
            ///

            _problemRepository.Save(Problems);

            //int problemId = 32;
            //Problem problem = new ProblemRepository().Get(problemId);
            //problem.Title = Title;

        }

    }

}