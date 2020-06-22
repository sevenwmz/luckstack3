using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebUI.Helper
{
    public class CaptchaHelper
    {
        public static Bitmap captchaBackGroundPixel(Bitmap image, Random random)
        {
            for (int i = 0; i < 200; i++)
            {
                image.SetPixel(random.Next(0, 100), random.Next(0, 30), Color.BurlyWood);
                image.SetPixel(random.Next(0, 100), random.Next(0, 30), Color.IndianRed);
                image.SetPixel(random.Next(0, 100), random.Next(0, 30), Color.DarkCyan);
                image.SetPixel(random.Next(0, 100), random.Next(0, 30), Color.DarkViolet);
            }
            return image;
        }
        public static Graphics captchaBackgroundDrawing(Graphics drawing, Random random)
        {
            for (int i = 0; i < 25; i++)
            {
                drawing.DrawCurve(new Pen(new SolidBrush(Color.Gray), 1), new Point[] { new Point
                    (random.Next(0, 100), random.Next(0, 30)), new Point(random.Next(0, 100), random.Next(0, 30)),new Point(random.Next(0, 100), random.Next(0, 30)) });

                drawing.DrawCurve(new Pen(new SolidBrush(Color.Chocolate), 1), new Point[] { new Point
                    (random.Next(0, 100), random.Next(0, 30)), new Point(random.Next(0, 100), random.Next(0, 30)),new Point(random.Next(0, 100), random.Next(0, 30)) });
            }
            return drawing;
        }
        public static Graphics captchaMaker(Random random, Graphics drawing, Bitmap image, int custom = 4)
        {
            //随机字符串池
            string subCaptcha = "1234567890QAZWSXEDCRFVTGBYHNUJMIKOLP";

            string captcha = "";
            for (int i = 0; i < custom; i++)
            {
                captcha = captcha + subCaptcha.Substring(random.Next(subCaptcha.Length), 1);
            }
            HttpContext.Current.Session[Const.SESSION_CAPTCHA] = captcha;
            drawing.DrawString(captcha, new Font("微软雅黑", 15),
                new SolidBrush(Color.SaddleBrown), 15, 3);

            return drawing;
        }
    }
}