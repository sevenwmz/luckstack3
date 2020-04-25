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
    public class ProblemModel : PageModel
    {

        public IList<Problem> Problems { set; get; }

        public int SumOfArticle { set; get; }

        private ProblemRepository _problem;
        public ProblemModel()
        {
            _problem = new ProblemRepository();
        }


        public void OnGet()
        {
            int pageIndex = Convert.ToInt32(Request.Query["pageIndex"]);
            int pageSize = 2;
            string exclude = Request.Query["exclude"];
            Problems = _problem.GetPaged(pageSize, pageIndex);
            SumOfArticle = _problem.GetSum();

            if (string.IsNullOrEmpty(exclude))
            {
                Problems = _problem.Get();
            }
            else
            {
                Problems = _problem.GetExclude(Enum.Parse<ProblemStatus>(exclude));
            }

            


        }
    }
}