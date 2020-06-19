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
            //ArticleNewModel model = new ArticleNewModel();
            //model.Series = new List<SelectListItem>();
            //model.Ad = new List<SelectListItem>();

            //Fake to take userId from Session
            
            ViewData["SeriesDropDownList"] = new SeriesService().GetDropDownList(new SeriesService().GetSeries(4));
            ViewData["AdDropDownList"] = new AdService().GetDropDownList(new AdService().GetAD(4));

            return View();
        }

        [HttpPost]
        public ActionResult New(ArticleNewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("New");
            }

            ///wanna take userInfo from session ,not yet,now i need to do DbSet<T>
            //string authorName = HttpContext.Session.Keys.ToString();
            //RegisterService authorId = new RegisterService();
            //authorId = authorId.GetByName(authorName);
            if (model.HasNewAd)
            {
                new AdService().Add(model.ContentOfAd,model.WebSite);
            }
            new ArticleService().Add(model);


            return View("/Article");
        }

    }
}