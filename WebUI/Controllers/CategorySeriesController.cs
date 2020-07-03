using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CategorySeriesController : BaseController
    {
        // GET: CategorySeries
        [ChildActionOnly]
        public PartialViewResult _CategorySeries(int id)
        {
            return PartialView(new SeriesService().GetCategorySeries(id));
        }
    }
}