using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdController : BaseController
    {
        private AdService _service;
        public AdController()
        {
            _service = new AdService();
        }

        // GET: Ad
        [ChildActionOnly]
        public ActionResult Index()
        {
            return View(_service.GetChildAD());
        }


        public void _DeleteAd(int id)
        {
            _service.Delete(id);
        }

    }
}