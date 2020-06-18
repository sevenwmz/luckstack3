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

            ///wanna take userInfo from session ,not yet,now i need to do DbSet<T>
            //string authorName = HttpContext.Session.Keys.ToString();
            //RegisterService authorId = new RegisterService();
            //authorId = authorId.GetByName(authorName);


            new ArticleService().Add(model);


            return View("/Article");
        }

    }
}