using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Captcha
{
    class ProgramNetFromWork
    {


        static void Main(string[] args)
        {
            Captcha.RefreshCaptcha();
            #region 2020.4.16异步作业

            Captcha.CaptchaAsync();


            //重构之前的验证码作业：
            //1.创建一个新的前台线程（Thread），在这个线程上运行生成随机字符串的代码
            //Thread thread = new Thread(new ThreadStart(Captcha.RefreshCaptcha));
            //Bitmap image = new Bitmap(200, 100); ;
            //Graphics drawing;

            //Random random = new Random();
            //int random_0_To_200 = random.Next(0, 200);
            //int random_0_To_100 = random.Next(0, 100);
            ////2.在一个任务（Task）中生成画布
            //Action draingMap = () =>
            //{
            //    Console.WriteLine("当前线程ID是： " + Thread.CurrentThread.ManagedThreadId);

            //    drawing = Graphics.FromImage(image);
            //};
            //Task task = new Task(draingMap);

            /////3.使用生成的画布，用两个任务完成：
            /////1.在画布上添加干扰线条
            /////2.在画布上添加干扰点
            /////
            //Parallel.Invoke(() =>
            //{
            //    Console.WriteLine("当前线程ID是： " + Thread.CurrentThread.ManagedThreadId);

            //    for (int i = 0; i < 200; i++)
            //    {
            //        image.SetPixel(random_0_To_200, random_0_To_200, Color.BurlyWood);
            //        image.SetPixel(random_0_To_200, random_0_To_200, Color.IndianRed);
            //        image.SetPixel(random_0_To_200, random_0_To_200, Color.DarkCyan);
            //        image.SetPixel(random_0_To_200, random_0_To_200, Color.DarkViolet);
            //    }

            //},
            //() =>
            //{
            //    drawing = Graphics.FromImage(image);
            //    for (int i = 0; i < 25; i++)
            //    {
            //        Console.WriteLine("当前线程ID是： " + Thread.CurrentThread.ManagedThreadId);

            //        drawing.DrawCurve(new Pen(new SolidBrush(Color.Gray), 1), 
            //            new Point[] { 
            //                new Point(random_0_To_200,random_0_To_100), 
            //                new Point(random_0_To_200,random_0_To_200),
            //                new Point(random_0_To_200, random_0_To_100) });

            //        drawing.DrawCurve(new Pen(new SolidBrush(Color.Chocolate), 1),
            //            new Point[] {
            //                new Point(random_0_To_200,random_0_To_100),
            //                new Point(random_0_To_200,random_0_To_200),
            //                new Point(random_0_To_200, random_0_To_100) });
            //    }
            //});
            ////随机验证码。
            //string subCaptcha = "1234567890QAZWSXEDCRFVTGBYHNUJMIKOLP";
            //string captcha = "";
            //for (int i = 0; i < 4; i++)
            //{
            //    captcha = captcha + subCaptcha.Substring(random.Next(subCaptcha.Length), 1);
            //}
            //drawing = Graphics.FromImage(image);
            //drawing.DrawString(
            //    captcha, new Font("微软雅黑", 35),
            //    new SolidBrush(Color.SaddleBrown), 45, 25);
            ////4.将生成的验证码图片异步的存入文件
            ////5.能捕获抛出的若干异常，并相应的处理
            ////6.以上作业，需要在控制台输出线程和Task的Id，以演示异步并发的运行。
            //Parallel.Invoke(() =>
            //{
            //    try
            //    {
            //        Console.WriteLine("当前线程ID是： "+Thread.CurrentThread.ManagedThreadId);
            //        image.Save(@"C:\Users\Administrator\source\repos\luckstack3\Captcha\CaptchaAsync.jpg",
            //                            ImageFormat.Jpeg);
            //        throw new Exception("人家大佬的作业要求");
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("我是一只异常，只是输出给你看，");
            //    }

            //});
            #endregion

            #region Email作业--之没写出来
            /// 现有一个txt文件，里面存放了若干email地址，使用分号（;）或者换行进行了分隔。
            /// 请删除其中重复的email地址，并按每30个email一行（行内用;分隔）重新组织

            //EmailSettle.MakerEail();

            //EmailSettle.DeleteDuplicateEmail();
            #endregion



            #region 画验证码作业

            ///Captcha Maker Method
            //Captcha.RefreshCaptcha();


            //Captcha Exception Method
            //Captcha.CaptchaInsertException("52plk");
            #endregion



        }
    }
}
