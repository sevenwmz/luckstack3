using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.MoneyTrade;

namespace WebUI.Controllers
{
    public class MoneyTradeController : BaseController
    {
        // GET: MoneyTrade
        public ActionResult Sale()
        {
            return View(new MoneyTradeService().GetCurrentUserLeftBMoney());
        }


        [HttpPost]
        public ActionResult Sale(SaleModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(model.ByFrom, "帮帮币出售事关重大，这里面的内容都要写一写呦！");
                return View(model);
            }
            new MoneyTradeService().FreezingMoney(model);

            ///Check and get purchaser email,and scend email to him;
            ///
            Global.EmailScend.SecendEmail(
                new ViewModel.EmailModel
                {
                    EmailAddress = "wangmingzhibj@163.com",
                    UserName = model.ByFrom
                },"传奇网站 18bang 交易提醒",null) ;


            //Actually here need jump to someWhere , and same time telling seller you alreday suss
            return Redirect("/Home/Index");
        }





    }
}