using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleService _articleService;
        public ArticleController()
        {
            _articleService = new ArticleService();
        }


        // GET: Article
        public ActionResult New()
        {
            ArticleNewModel model = new ArticleNewModel();
            model.Series = new List<SelectListItem>();
            model.Ad = new List<SelectListItem>();
            ViewData["SeriesDropDownList"] = new ArticleService().GetDropDownList(model.Series);
            ViewData["AdDropDownList"] = new ArticleService().GetDropDownList(model.Ad);

            return View();
        }
        [HttpPost]
        public ActionResult New(ArticleNewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("/Article/New");
            }
            _articleService.Add(model);


            return View("/Article");
        }

    }
}