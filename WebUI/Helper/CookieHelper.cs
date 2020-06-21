using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.UIFunction
{
    public class CookieHelper
    {
        public static void AddCookie(int userId,string password,bool RemenberMe = false)
        {
            HttpCookie logIncookie = new HttpCookie(Const.COOKIE_NAME);
            logIncookie.Values["id"] = userId.ToString();
            logIncookie.Values["pwd"] = password;
            if (RemenberMe)
            {
                logIncookie.Expires = DateTime.Now.AddDays(15);
            }
            HttpContext.Current.Response.Cookies.Add(logIncookie);
        }
    }
}