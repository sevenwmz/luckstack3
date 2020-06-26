using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using ViewModel.ChildAction;

namespace WebUI.Controllers
{
    public class ChildActionController : BaseController
    {
        // GET: ChildAction
        public PartialViewResult _Keyword()
        {
            return PartialView(new KeywordsService().GetChildKeywords(1));
        }

        [HttpPost]
        [ChildActionOnly]
        public PartialViewResult _Keyword(ChildKeywordModel model)
        {
            if (model.FindKeyword == null)
            {
                return PartialView(new KeywordsService().GetChildKeywords(new Random().Next(1,10)));
            }

            //Nothing for find keyword..
            return PartialView();
        }

    }
}