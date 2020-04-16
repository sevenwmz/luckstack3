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


            #region 2020.4.16异步作业
            //重构之前的验证码作业：
            //1.创建一个新的前台线程（Thread），在这个线程上运行生成随机字符串的代码
            Thread thread = new Thread(new ThreadStart(Captcha.RefreshCaptcha));

            //2.在一个任务（Task）中生成画布
            Action draingMap = () =>
            {
                Bitmap image = new Bitmap(200, 100);
                Graphics drawing = Graphics.FromImage(image);
            };
            Task task = new Task(draingMap);
            #endregion

            #region MyRegion
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
