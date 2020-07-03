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

        #region Article Category
        // GET: Article/Single
        public ActionResult Category(int id)
        {
            bool asc = false;
            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString[Const.SORT]))
            {
                asc = HttpContext.Request.QueryString[Const.SORT].ToString() == "Asc" ? false : true ;
            }

            int takeArticleNum = 10;
            if (!string.IsNullOrEmpty(HttpContext.Request.QueryString[Const.SIZE]))
            {
                takeArticleNum = HttpContext.Request.QueryString[Const.SIZE].ToString() == "50" ? 50 : 10;
                if (HttpContext.Request.QueryString[Const.SIZE].Contains("1000"))
                {
                    takeArticleNum = 1000;
                }
            }
            ArticleCategoryModel model = new ArticleCategoryModel();
            model = _service.GetAuthorCategory(id, asc, takeArticleNum);
            model.SumOfCategory = _service.GetAuthorCategoryCount(id);
            return View(model);
        }
        #endregion

        #region Artile Auhtor
        // GET: Article/Auhtor
        public ActionResult Author(int id, int pageId = 1)
        {
            AritcleAuthorModel model = new AritcleAuthorModel();
            model = _service.GetAuthorArticle(id, 2, pageId);
            model.SumOfAuthor = _service.GetAuthorCount(id);

            if (model.SumOfAuthor % 2 == 1)
            {
                model.SumOfAuthor += 1;
            }

            return View(model);
        }
        #endregion

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
                model.Summary = HtmlSecurityHelper.HtmlSecurity(model.Body, true);
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

            model.Body = HtmlSecurityHelper.HtmlSecurity(model.Body);
            if (string.IsNullOrEmpty(model.Summary))
            {
                model.Summary = HtmlSecurityHelper.HtmlSecurity(model.Body, true);
            }
            model.Summary = SummaryHelper.GetSumarry(model.Summary);

            _service.Update(model);

            return Redirect("/Article/Page-1");
        }

        #endregion




    }
}