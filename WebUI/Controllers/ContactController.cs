using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Contact;

namespace WebUI.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View(new ContactService().GetContactInfo());
        }

        [HttpPost]
        public ActionResult Index(ContactModel model)
        {
            if ("resetFix" == HttpContext.Request.Form.Get("submit").ToString())
            {
                new ContactService().Change(model);
                return Redirect("/Home/Index");
            }

            new ContactService().Add(model);
            return Redirect("/Home/Index");
        }
    }
}