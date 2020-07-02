using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductServices;

namespace WebUI.Controllers
{
    public class SeriesController : BaseController
    {
        // GET: Series
        [ChildActionOnly]
        public PartialViewResult _Series(int id)
        {
            return PartialView(new SeriesService().GetSideSeries(id));
        }
    }
}