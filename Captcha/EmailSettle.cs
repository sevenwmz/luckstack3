using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha
{
    /// <summary>
    /// 现有一个txt文件，里面存放了若干email地址，使用分号（;）或者换行进行了分隔。
    /// 请删除其中重复的email地址，并按每30个email一行（行内用;分隔）重新组织
    /// </summary>
    class EmailSettle
    {

        /// <summary>
        /// Email生成随机数量
        /// </summary>
        /// <param name="value">生成的Email随机数量，不指定默认为300</param>
        public static void MakerEail(int value =300)
        {
            //文件存放路径
            string path = @"C:\Users\Administrator\source\repos\luckstack3\Captcha\Email.txt";
            
            //Email随机生成器
            using (StreamWriter writer = File.AppendText(path))
            {
                Random random = new Random();
                string emailTail = "@qq.com;";
                for (int i = 0; i < value; i++)
                {
                    writer.Write(Convert.ToString(random.Next(100000000, 999999999)) + emailTail);
                }
                writer.Flush();
            }
            
        }





    }
}
