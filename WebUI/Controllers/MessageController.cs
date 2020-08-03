using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Message;

namespace WebUI.Controllers
{
    public class MessageController : BaseController
    {
        private MessageMineService _service;
        public MessageController()
        {
            _service = new MessageMineService();
        }


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
            MessageMineService service = new MessageMineService();

            string getReturn = HttpContext.Request.Form.Get("submit").ToString();
            foreach (var item in model.Items)
            {
                if (item.CheckAll)
                {
                    item.HasCheck = true;
                }
                if (item.HasCheck)
                {
                    if ("read" == getReturn)
                    {
                        service.ChangeHasRead(item.Id);
                    }
                    else if ("delete" == getReturn)
                    {
                        service.RemoveMessage(item.Id);
                    }
                }
            }
            return Redirect("message/mine");
        }

        public JsonResult _New()
        {
            return Json(_service.HasNewMessage(),JsonRequestBehavior.AllowGet);
        }
    }
}