using ProductServices;
using System;
using System.Collections.Generic;
using WebUI.Helper;
using System.Web.Mvc;
using ViewModel;
using ViewModel.Article;

namespace WebUI.Controllers
{
    public class ArticleController : BaseController
    {
        private ArticleService _service;
        public ArticleController()
        {
            _service = new ArticleService();
        }

        #region Article Single

        // GET: Article/Single
        public ActionResult Single(int id)
        {
            ArticleSingleModel model = new ArticleSingleModel();
            model = _service.GetSingleArticle(id);
            return View(model);
        }
        #endregion

        #region Article Index

        // GET: Article/Index
        public ActionResult Index(int id = 1)
        {
            ArticleIndexModel index = new ArticleIndexModel { Items = new List<ArticleItemsModel>() };
            index = _service.GetArticles(2, id);
            index.SumOfArticle = _service.GetCount();
            return View(index);
        }
        #endregion

        #region Article New

        // GET: Article/New
        public ActionResult New()
        {
            int userId = _service.CurrentUserId.Value;
            ViewData["SeriesDropDownList"] = new SeriesService().GetDropDownList(new SeriesService().GetSeries(userId));
            ViewData["AdDropDownList"] = new AdService().GetDropDownList(new AdService().GetAD(userId));

            return View();
        }

        [HttpPost]
        public ActionResult New(ArticleNewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("New");
            }

            if (model.HasNewAd)
            {
                new AdService().Add(model.ContentOfAd, model.WebSite);
            }

            model.Body = HtmlSecurityHelper.HtmlSecurity(model.Body);

            if (string.IsNullOrEmpty(model.Summary))
            {
                model.Summary = HtmlSecurityHelper.HtmlSecurity(model.Body,true);
            }
            model.Summary = SummaryHelper.GetSumarry(model.Summary);

            int articleId = _service.Add(model);


            return Redirect($"/Article/{articleId}");
        }



        #endregion

        #region Article Edit
        // GET: Article/Edit
        public ActionResult Edit(int? Id)
        {
            int userId = new ArticleService().CurrentUserId.Value;
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

        #endregion



       
    }
}