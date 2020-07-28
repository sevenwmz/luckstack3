﻿using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.ChildAction;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private ChatService _service;
        public HomeController()
        {
            _service = new ChatService();
        }

        #region Old Area
        public ActionResult Index()
        {
            return View(_service.CurrentUserId);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion

        #region ChatRoom Area


        public PartialViewResult _ChatRoom(int count = 0)
        {
            return PartialView(_service.GetHistoryChat(count));
        }

        public ActionResult _MyChat(int id)
        {
            return View(_service.GetChat(id));
        }

        [HttpPost]
        public ActionResult _MyChat(ChatItemModel chatModel)
        {
            int id = _service.SaveCurrentChat(chatModel);
            return Redirect($"/Home/_MyChat?id={id}");
        }
        #endregion

    }
}