using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Helper;

namespace WebUI.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult Captcha()
        {
            Bitmap image = new Bitmap(100, 30);
            Graphics drawing = Graphics.FromImage(image);
            drawing.Clear(Color.White);
            Random random = new Random();

            image = CaptchaHelper.captchaBackGroundPixel(image, random);
            drawing = CaptchaHelper.captchaBackgroundDrawing(drawing, random);
            CaptchaHelper.captchaMaker(random, drawing, image);

            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            return File(stream.ToArray(),"image/jpg");
        }
    }
}