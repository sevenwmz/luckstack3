using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Captcha
{
    class Captcha
    {
        public delegate Graphics DraingMap(Bitmap image);
        #region CaptchaAsync
        public static void CaptchaAsync()
        {
            Thread thread = new Thread(new ThreadStart(Captcha.RefreshCaptcha));
            Bitmap image = new Bitmap(200, 100);
            Graphics drawing = Graphics.FromImage(image);
            drawing.Clear(Color.White);
            Random random = new Random();
            //int random_0_To_200 = random.Next(0, 200);
            //int random_0_To_100 = random.Next(0, 100);
            //2.在一个任务（Task）中生成画布
            //DraingMap draingMap = _draingMap;

            //其实这里做异步的画板生成有点坑后面的。
            draingMap(image);


            ///3.使用生成的画布，用两个任务完成：
            ///1.在画布上添加干扰线条
            ///2.在画布上添加干扰点
            ///

            pixel(image, random);
            line(drawing, random);
            captcha(random, drawing, image);


            //4.将生成的验证码图片异步的存入文件
            //5.能捕获抛出的若干异常，并相应的处理
            //6.以上作业，需要在控制台输出线程和Task的Id，以演示异步并发的运行。
            saveImage(image);
        }

        /// <summary>
        /// 生成画布
        /// </summary>
        /// <param name="image"></param>
        private static async /*Task<Graphics>*/ void draingMap(Bitmap image)
        {
            Graphics drawing;

            /*Graphics resule = */
            await Task<Graphics>.Run(() =>
            {
                Console.WriteLine("当前线程ID是： " + Thread.CurrentThread.ManagedThreadId);

                drawing = Graphics.FromImage(image);
            });
            //return resule;
        }

        /// <summary>
        /// 生成像素点
        /// </summary>
        /// <param name="image"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        private static async Task<Bitmap> pixel(Bitmap image, Random random)
        {
            await Task<Graphics>.Run(() =>
            {
                for (int i = 0; i < 25; i++)
                {
                    image.SetPixel(random.Next(0, 200), random.Next(0, 200), Color.BurlyWood);
                    image.SetPixel(random.Next(0, 200), random.Next(0, 200), Color.IndianRed);
                    image.SetPixel(random.Next(0, 200), random.Next(0, 200), Color.DarkCyan);
                    image.SetPixel(random.Next(0, 200), random.Next(0, 200), Color.DarkViolet);
                }
            });
            return image;
        }
        /// <summary>
        /// 生成干扰线条
        /// </summary>
        /// <param name="drawing"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        private static async Task<Graphics> line(Graphics drawing, Random random)
        {
            await Task<Graphics>.Run(() =>
            {
                for (int i = 0; i < 25; i++)
                {
                    Console.WriteLine("当前线程ID是： " + Thread.CurrentThread.ManagedThreadId);

                    drawing.DrawCurve(new Pen(new SolidBrush(Color.Gray), 1),
                        new Point[] {
                            new Point(random.Next(0,200),random.Next(0,100)),
                            new Point(random.Next(0,200),random.Next(0,100)),
                            new Point(random.Next(0,200), random.Next(0,100)) });

                    drawing.DrawCurve(new Pen(new SolidBrush(Color.Chocolate), 1),
                        new Point[] {
                            new Point(random.Next(0,200),random.Next(0,100)),
                            new Point(random.Next(0,200),random.Next(0,100)),
                            new Point(random.Next(0,200), random.Next(0,100)) });
                }
            });
            return drawing;
        }
        /// <summary>
        /// 生成随机验证码
        /// </summary>
        /// <param name="random"></param>
        /// <param name="drawing"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        private static async Task<Graphics> captcha(Random random, Graphics drawing, Bitmap image)
        {
            //随机验证码。
            await Task<Graphics>.Run(() =>
            {
                Console.WriteLine("当前线程ID是： " + Thread.CurrentThread.ManagedThreadId);

                string subCaptcha = "1234567890QAZWSXEDCRFVTGBYHNUJMIKOLP";
                string captcha = "";
                for (int i = 0; i < 4; i++)
                {
                    captcha = captcha + subCaptcha.Substring(random.Next(subCaptcha.Length), 1);
                }
                drawing = Graphics.FromImage(image);
                drawing.DrawString(
                    captcha, new Font("微软雅黑", 35),
                    new SolidBrush(Color.SaddleBrown), 45, 25);
            });
            return drawing;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="image"></param>
        private static async void saveImage(Bitmap image)
        {
            await Task<Graphics>.Run(() =>
            {
                Console.WriteLine("当前线程ID是： " + Thread.CurrentThread.ManagedThreadId);
                try
                {
                    Console.WriteLine("当前线程ID是： " + Thread.CurrentThread.ManagedThreadId);
                    image.Save(@"C:\Users\Administrator\source\repos\luckstack3\Captcha\CaptchaAsync.jpg",
                                        ImageFormat.Jpeg);
                    throw new Exception("人家大佬的作业要求");
                }
                catch (Exception)
                {
                    Console.WriteLine("我是一只异常，只是输出给你看，");
                }
            });
        }
        #endregion





        /// <summary>
        ///  参考一起帮的登录页面，绘制一个验证码图片，存放到当前项目中。验证码应包含：随机字符串,
        ///  混淆用的各色像素点,混淆用的直线（或曲线）
        /// </summary>
        public static void RefreshCaptcha()
        {
            Bitmap image = new Bitmap(200, 100);
            Graphics drawing = Graphics.FromImage(image);

            drawing.Clear(Color.White);

            Random random = new Random();

            for (int i = 0; i < 200; i++)
            {
                image.SetPixel(random.Next(0, 200), random.Next(0, 100), Color.BurlyWood);
                image.SetPixel(random.Next(0, 200), random.Next(0, 100), Color.IndianRed);
                image.SetPixel(random.Next(0, 200), random.Next(0, 100), Color.DarkCyan);
                image.SetPixel(random.Next(0, 200), random.Next(0, 100), Color.DarkViolet);
            }
            for (int i = 0; i < 25; i++)
            {
                drawing.DrawCurve(new Pen(new SolidBrush(Color.Gray), 1),
                    new Point[]
                    {
                        new Point(random.Next(0, 200), random.Next(0, 100)),
                        new Point(random.Next(0, 200), random.Next(0, 100)),
                        new Point(random.Next(0, 200), random.Next(0, 100))
                    });

                drawing.DrawCurve(new Pen(new SolidBrush(Color.Chocolate), 1), new Point[]
                    {
                        new Point(random.Next(0, 200), random.Next(0, 100)),
                        new Point(random.Next(0, 200), random.Next(0, 100)),
                        new Point(random.Next(0, 200), random.Next(0, 100))
                    });
            }
            string subCaptcha = "1234567890QAZWSXEDCRFVTGBYHNUJMIKOLP";
            string captcha = "";
            for (int i = 0; i < 4; i++)
            {
                captcha = captcha + subCaptcha.Substring(random.Next(subCaptcha.Length), 1);
            }

            drawing.DrawString(captcha,
                new Font("微软雅黑", 35),
                new SolidBrush(Color.DarkOliveGreen), 45, 25);
            image.Save(@"C:\Users\Administrator\source\repos\luckstack3\Captcha\Captcha.jpg", ImageFormat.Jpeg);
        }

        #region 屎山一样的异常验证码作业
        /// <summary>
        /// 将生成验证码的代码拆分成若干个方法，并为其添加异常机制，要求能够：o显式的抛出一个自定义异常 
        /// 捕获并包裹一个被抛出的异常，记入日志文件，然后再次抛出，o根据不同的异常，给用户相应的友好的异常提示 
        /// 使用using释放文件资源
        /// </summary>
        public static void CaptchaInsertException(string custom = null)//需要自己传入一个验证码，要求不得大于4个字符
        {
            //主方法，生成画布添加背景颜色
            Bitmap image = new Bitmap(200, 100);
            Graphics drawing = Graphics.FromImage(image);
            drawing.Clear(Color.White);

            //添加随机种子
            Random random = new Random();

            //生成背景像素点
            Captcha.captchaBackGroundPixel(image, random);

            //生成背景干扰线条
            Captcha.captchaBackgroundDrawing(drawing, random);



            //为了捕获异常特意声明的一个Try catch
            try
            {
                if (custom.Length > 4)
                {//自定义的异常
                    throw new HomeworkException("传入的验证码请不要超过4个字符");
                }
                else
                {//输入正确就跑到正常的执行手段里面去。
                    Captcha.captchaMaker(random, drawing, image, custom);
                }
            }
            catch (HomeworkException Record)
            {
                string path = @"C:\Users\Administrator\source\repos\luckstack3\Captcha\Log.txt";
                using (StreamWriter writer = File.AppendText(path))
                {
                    DateTime date = DateTime.Now;//设置日志时间
                    string time = date.ToString("yyyy-MM-dd HH:mm:ss");


                    //日志存放
                    //writer = File.AppendText(path);
                    writer.WriteLine("异常时间" + time);
                    writer.WriteLine("异常对象" + Record.Source);
                    writer.WriteLine("调用堆栈" + Record.StackTrace.Trim());
                    writer.WriteLine("调用堆栈" + Record.ToString());

                    writer.Flush();
                }

                //重新抛出
                throw new HomeworkException("传入的验证码请不要超过4个字符");
            }
            catch (Exception)
            {
                throw new Exception("正确传入4个字符的自定义验证码");
            }
            //生成随机验证码
            Captcha.captchaMaker(random, drawing, image);

            //存储图片
            image.Save(@"C:\Users\Administrator\source\repos\luckstack3\Captcha\Captcha.jpg", ImageFormat.Jpeg);

        }

        /// <summary>
        /// 服务于主方法，这个方法是是生成背景像素点
        /// </summary>
        /// <param name="image"></param>
        /// <param name="random"></param>
        private static Bitmap captchaBackGroundPixel(Bitmap image, Random random)
        {
            for (int i = 0; i < 200; i++)
            {
                image.SetPixel(random.Next(0, 200), random.Next(0, 100), Color.BurlyWood);
                image.SetPixel(random.Next(0, 200), random.Next(0, 100), Color.IndianRed);
                image.SetPixel(random.Next(0, 200), random.Next(0, 100), Color.DarkCyan);
                image.SetPixel(random.Next(0, 200), random.Next(0, 100), Color.DarkViolet);
            }
            return image;

        }

        /// <summary>
        /// 服务于主方法，这个方法是是生成背景干扰线条
        /// </summary>
        /// <param name="drawing"></param>
        /// <param name="random"></param>
        private static Graphics captchaBackgroundDrawing(Graphics drawing, Random random)
        {
            for (int i = 0; i < 25; i++)
            {
                drawing.DrawCurve(new Pen(new SolidBrush(Color.Gray), 1), new Point[] { new Point
                    (random.Next(0, 200), random.Next(0, 100)), new Point(random.Next(0, 200),
                    random.Next(0, 100)),new Point(random.Next(0, 200), random.Next(0, 100)) });

                drawing.DrawCurve(new Pen(new SolidBrush(Color.Chocolate), 1), new Point[] { new Point
                    (random.Next(0, 200), random.Next(0, 100)), new Point(random.Next(0, 200), random.Next(0, 100)), new Point(random.Next(0, 200), random.Next(0, 100)) });
            }
            return drawing;
        }


        private static Graphics captchaMaker(Random random, Graphics drawing, Bitmap image, string custom = null)
        {
            //随机字符串池
            string subCaptcha = "1234567890QAZWSXEDCRFVTGBYHNUJMIKOLP";

            string captcha = "";
            for (int i = 0; i < 4; i++)
            {
                captcha = captcha + subCaptcha.Substring(random.Next(subCaptcha.Length), 1);
            }

            //只是为了捕获异常强行加入的一个判断，顺应前面
            if (custom != null)
            {
                captcha = custom;
            }

            drawing.DrawString(captcha, new Font("微软雅黑", 35),
                new SolidBrush(Color.SaddleBrown), 45, 25);

            return drawing;
        }
        #endregion

    }

    [Serializable]
    internal class HomeworkException : Exception
    {
        public HomeworkException()
        {
        }

        public HomeworkException(string message) : base(message)
        {
        }

        public HomeworkException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HomeworkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
