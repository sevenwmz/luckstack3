using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha
{        

    public class EmailSettle
    {
        //读写同一个文档
        public EmailSettle(string path)
        {
            _path = path;
        }

        private string _path;

        /// <summary>
        /// Email生成随机数量
        /// </summary>
        /// <param name="value">生成的Email随机数量，不指定默认为300</param>
        public static void MakerEmail(int value = 300)
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



        /// <summary>
        /// 读取和删除其中重复的email地址，2个方法
        /// </summary>
        public void GetEmail()
        {
            if (!File.Exists(this._path))
            {
                throw new FileNotFoundException("没有找到文件");
            }

            //读取文件内容 字符串拆分
            string[] getEmail = File.ReadAllLines(this._path);
            string get = getEmail[0];
            getEmail = get.Split(';');

            filter(getEmail);
        }
        private string[] filter(string[] emails)
        {
            emails =  emails.Distinct().ToArray();
            return emails;
        }



        public void Write(string path, string[] emails)
        {

        }
    }
}
