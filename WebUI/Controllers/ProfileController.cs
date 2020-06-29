using ProductServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Profile;
using G = Global;

namespace WebUI.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Profile
        public ActionResult Write()
        {
            #region Year and Month
            WriteModel model = new WriteModel();
            model.Year = new List<SelectListItem>();
            for (int i = DateTime.Now.Year; i > 1930; i--)
            {
                model.Year.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            model.Month = new List<SelectListItem>();
            for (int i = 12; i > 0; i--)
            {
                model.Month.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            #endregion

            #region Frist and Scend Keyword
            KeywordsService keywordsService = new KeywordsService();
            ViewData[G.Const.FRISTKEYWORD] = keywordsService.GetDropDownList(true);
            ViewData[G.Const.SCENDKEYWORD] = keywordsService.GetDropDownList(false);
            #endregion
            return View(model);
        }

        [HttpPost]
        public ActionResult Write(WriteModel model,HttpPostedFileBase icon)
        {
            try
            {
                int onwerId = 0;
                if (model != null)
                {
                    onwerId = new ProfileService().SaveUserInfo(model);
                }

                if (icon != null)
                {
                    string fileExname = Path.GetExtension(icon.FileName);

                    icon.SaveAs(Server.MapPath(
                        Path.Combine("/Img/Icon/", onwerId + fileExname)));
                }
            }
            catch (Exception)
            {
                //Add Log save
                throw;
            }


            return Redirect("/Home/Index");
        }
    }
}