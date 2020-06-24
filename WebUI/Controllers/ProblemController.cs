﻿using InterfaceBang;
using ProductServices;
using System.Web.Mvc;
using ViewModel.Problem;

namespace WebUI.Controllers
{
    public class ProblemController : Controller
    {

        private KeywordsService _keywordsService = new KeywordsService();
        private ProblemService _problemService;


        private IProblemService _service;

        public ProblemController(IProblemService service)
        {
            this._service = service;
        }
        public ProblemController()
        {
            _problemService = new ProblemService();
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
    }
}