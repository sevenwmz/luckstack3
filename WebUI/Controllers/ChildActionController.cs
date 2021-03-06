﻿using ProductServices;
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
        #region _Keyword Area
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
                return PartialView(new KeywordsService().GetChildKeywords(new Random().Next(1, 10)));
            }

            //Nothing for find keyword..
            return PartialView();
        }
        #endregion

        #region _Rank Area
        public PartialViewResult _Rank()
        {
            return PartialView(new ChildRankService().GetRank(8));
        }

        #endregion

        #region _AD Area
        public PartialViewResult _AD()
        {
            return PartialView(new AdService().GetChildAD(6));
        }
        #endregion
    }
}