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
        #region Old Area
        public ActionResult Index()
        {
            return View();
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


        public PartialViewResult _ChatRoom(int count = 0)
        {

            return PartialView(new ChatService().GetHistoryChat(count));
        }

        [HttpPost]
        [ChildActionOnly]
        public PartialViewResult _ChatRoom(ChatRoomModel chatModel)
        {
            new ChatService().SaveCurrentChat(chatModel);
            return PartialView();
        }
    }
}