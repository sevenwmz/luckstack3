using ProductServices;
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

        public ActionResult _ChatRoomAjax(int id = 0)
        {
            return View(_service.GetlatestChat(id));
        }
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
            //here i don't know how to send error to ajax suggest.
            if (string.IsNullOrWhiteSpace(chatModel.Content))
            {
                return View(false);
            }
            int id = _service.SaveCurrentChat(chatModel);
            return Redirect($"/Home/_MyChat?id={id}");
        }



        public ActionResult _MyReplyChat(int id)
        {
            return View(_service.GetChat(id));
        }
        [HttpPost]
        public ActionResult _MyReplyChat(ChatItemModel chatModel)
        {
            if (string.IsNullOrWhiteSpace(chatModel.Content))
            {
                return View(false);
            }

            int id = _service.SaveCurrentChat(chatModel);
            return Redirect($"/Home/_MyReplyChat?id={id}");
        }
        #endregion

    }
}