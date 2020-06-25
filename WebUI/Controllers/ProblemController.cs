using InterfaceBang;
using ProductServices;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModel.Problem;

namespace WebUI.Controllers
{
    public class ProblemController : Controller
    {

        private KeywordsService _keywordsService = new KeywordsService();
        private ProblemService _problemService;
        public ProblemController()
        {
            _problemService = new ProblemService();
        }
        #region For DI
        private IProblemService _service;

        public ProblemController(IProblemService service)
        {
            this._service = service;
        }

        #endregion

        // GET: Problem
        public ActionResult Index(int id = 1)
        {
            ProblemIndexModel problem = new ProblemIndexModel { Items = new List<ProblemItemModel>() };

            return View(problem);
        }

        // GET: Problem
        public ActionResult New()
        {
            ViewData["FristDropDownKeywords"] = _keywordsService.GetDropDownList(true);
            ViewData["SecendDropDownKeywords"] = _keywordsService.GetDropDownList(false);

            return View();
        }
        [HttpPost]
        public ActionResult New(ProblemNewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _problemService.Add(model);

            return RedirectToRoute("ArticleIndex");
        }



        // GET: Problem
        public ActionResult Edit(int Id)
        {
            ViewData["FristDropDownKeywords"] = _keywordsService.GetDropDownList(true);
            ViewData["SecendDropDownKeywords"] = _keywordsService.GetDropDownList(false);
            return View(new ProblemService().GetEditProblem(Id));
        }
        public ActionResult Edit(ProblemNewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            new ProblemService().Update(model);
            return Redirect("/Article/Page-1");
        }







    }
}