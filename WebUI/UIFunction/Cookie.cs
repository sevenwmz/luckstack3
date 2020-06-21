using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.UIFunction
{
    public class Cookie
    {
        public void AddCookie(int userId,string password)
        {
            HttpCookie logIncookie = new HttpCookie(Const.COOKIE_NAME);
            logIncookie.Values["id"] = userId.ToString();
            logIncookie.Values["pwd"] = password;
        }
    }
}