using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using ViewModel.Article;

namespace WebUI.Controllers
{
    public class ArticleController : BaseController
    {
        int userId;
        private ArticleService _service;
        public ArticleController()
        {
            userId = new BaceService().CurrentUserId.Value;
            _service = new ArticleService();
        }


        // GET: Article/Single
        public ActionResult Single(int id)
        {
            ArticleSingleModel model = new ArticleSingleModel();
            model = _service.GetSingleArticle(id);
            return View(model);
        }


        // GET: Article/Index
        public ActionResult Index(int id = 1)
        {
            ArticleIndexModel index = new ArticleIndexModel { Items = new List<ArticleItemsModel>()};
            ArticleService articleService = new ArticleService();
            index = articleService.GetArticles(2, id);
            index.SumOfArticle = articleService.GetCount();
            return View(index);
        }

        // GET: Article/New
        public ActionResult New()
        {

            ViewData["SeriesDropDownList"] = new SeriesService().GetDropDownList(new SeriesService().GetSeries(userId));
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

            if (model.HasNewAd)
            {
                new AdService().Add(model.ContentOfAd,model.WebSite);
            }
            new ArticleService().Add(model);


            return Redirect("/Article/Page-1");
        }

        // GET: Article/Edit
        public ActionResult Edit(int? Id)
        {
            ViewData["SeriesDropDownList"] = new SeriesService().GetDropDownList(new SeriesService().GetSeries(userId));
            ViewData["AdDropDownList"] = new AdService().GetDropDownList(new AdService().GetAD(userId));
            return View(new ArticleService().GetEditArticle(Id));
        }

        [HttpPost]
        public ActionResult Edit(AritcleEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }

            if (model.HasNewAd)
            {
                new AdService().Add(model.ContentOfAd, model.WebSite);
            }
            new ArticleService().Update(model);

            return Redirect("/Article/Page-1");
        }

    }
}