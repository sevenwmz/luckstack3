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
            ViewData[G.Const.YEAR] = model.Year;

            model.Month = new List<SelectListItem>();
            for (int i = 12; i > 0; i--)
            {
                model.Month.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            ViewData[G.Const.MONTH] = model.Month;
            #endregion

            #region Constellation
            ////model.Constellation = new List<SelectListItem>();
            //string[] prepareConstellation = ;
            ////for (int i = 0; i < prepareConstellation.Length; i++)
            ////{
            ////    model.Constellation.Add(new SelectListItem { Text = prepareConstellation[i].ToString(), Value = i.ToString() });
            ////}
            //model.Constellation =;
            //ViewData[G.Const.CONSTELLATION] = model.Constellation;
            #endregion

            #region Frist and Scend Keyword
            KeywordsService keywordsService = new KeywordsService();
            ViewData[G.Const.FRISTKEYWORD] = keywordsService.GetDropDownList(true);
            ViewData[G.Const.SCENDKEYWORD] = keywordsService.GetDropDownList(false);
            #endregion
            return View();
        }

        [HttpPost]
        public ActionResult Write(WriteModel model,HttpPostedFileBase icon)
        {
            new ProfileService().SaveUserInfo(model);


            string fileName = Path.GetFileName(icon.FileName);
            string path = "/Img/Icon" + new BaceService().CurrentUserId.Value.ToString() + fileName; 
            icon.SaveAs(Server.MapPath(path));


            return Redirect("/Home/Index");
        }
    }
}