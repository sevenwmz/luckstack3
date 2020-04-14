using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha
{
    class ProgramNetFromWork
    {
        static void Main(string[] args)
        {


            ///Captcha Maker Method.
            Captcha.RefreshCaptcha();

            /////Captcha Exception Method
            Captcha.CaptchaInsertException("52plk");


        }
    }
}
