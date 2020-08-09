using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.AdInWidget;

namespace WebUI.Controllers
{
    public class AdController : BaseController
    {
        private AdService _service;
        public AdController()
        {
            _service = new AdService();
        }
        #region AdContent
        // GET: Ad
        [ChildActionOnly]
        public ActionResult _Index()
        {
            return View(_service.GetChildAD());
        }

        public void _DeleteAd(int id)
        {
            _service.Delete(id);
        }
        #endregion

        #region AdDate
        [ChildActionOnly]
        public ActionResult _AdPosition()
        {
            return View();
        }

        public ActionResult _DateOfAd(int id)
        {
            return View(new AdDateService().GetAdPositionBy(id));
        }
        #endregion
    }
}