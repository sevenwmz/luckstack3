using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Message;

namespace WebUI.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Mine(int id = 1)
        {
            MineModel model = new MineModel();
            model = new MessageMineService().GetMessage(id, 2);
            model.SumOfMessage = new MessageMineService().GetCurrentUserMessageCount();
            if ((model.SumOfMessage % 2) != 0)
            {
                model.SumOfMessage += 1;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Mine(MineModel model)
        {


            return View();
        }
    }
}