using InterfaceBang;
using ProductServices;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModel.Problem;

namespace WebUI.Controllers
{
    public class ProblemController : BaseController
    {

        private KeywordsService _keywordsService ;
        private ProblemService _problemService;
        public ProblemController()
        {
            _problemService = new ProblemService();
            _keywordsService = new KeywordsService();
        }
        #region For DI
        private IProblemService _service;

        public ProblemController(IProblemService service)
        {
            this._service = service;
        }

        #endregion


        #region Problem Single Area
        public ActionResult Single(int Id)
        {
            ProblemSingleModel singleModel = new ProblemSingleModel();
            singleModel = _problemService.GetSingelProblem(Id);
            return View(singleModel);
        }
        #endregion

        #region Problem Index Area
        // GET: Problem
        public ActionResult Index(int id = 1)
        {
            ProblemIndexModel problem = new ProblemIndexModel { Items = new List<ProblemItemModel>() };
            problem = _problemService.GetIndexPage(2, id);
            problem.SumOfProblem = _problemService.Count();
            return View(problem);
        }
        #endregion

        #region Problem New Area
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

            return RedirectToAction("Index", new { id = 1 });
        }
        #endregion

        #region Problem Edit Area
        // GET: Problem
        public ActionResult Edit(int Id)
        {
            ViewData["FristDropDownKeywords"] = _keywordsService.GetDropDownList(true);
            ViewData["SecendDropDownKeywords"] = _keywordsService.GetDropDownList(false);
            return View(new ProblemService().GetEditProblem(Id));
        }
        public ActionResult Edit(ProblemEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            new ProblemService().Update(model);
            return Redirect("/Problem/Page-1");
        }
        #endregion


    }
}