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
    public class EmailSettle
    {

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
        /// 现有一个txt文件，里面存放了若干email地址，使用分号（;）或者换行进行了分隔。
        /// 请删除其中重复的email地址，并按每30个email一行（行内用;分隔）重新组织
        /// </summary>
        public static void DeleteDuplicateEmail()
        {
            string path = @"C:\Users\Administrator\source\repos\luckstack3\Captcha\Email.txt";

            string copyPath = @"C:\Users\Administrator\source\repos\luckstack3\Captcha\CopyEmail.txt";

            ///需要先计算从0开始到；位置的字符串长度，然后去匹配，
            ///先和一样长度的匹配，如果长度一样，在匹配所有位置的数字是否一样，一样就删除掉匹配字符串
            ///一直删除到最后没有为止
            ///
            //File.Copy(path, copyPath);

            //File.OpenRead(path);
            //Distinct();
        }

        public static void SkipEmail()
        {
            string path = @"C:\Users\Administrator\source\repos\luckstack3\Captcha\Email.txt";
            //File.OpenRead(path);
            //FileStream fileStream = File.ReadAllText(path);
        }

        //读写同一个文档
        public EmailSettle(string path)
        {
            _path = path;
        }

        private string _path;

        public IList<string> GetEmail()
        {
            if (!File.Exists(this._path))
            {
                throw new FileNotFoundException("没有找到文件");
            }

            StringBuilder stringBuilder = new StringBuilder();


            string target = ";";
            string[] getEmail = File.ReadAllLines(this._path);
            string get = getEmail[0];
            IList<string> saveEmail = new List<string>();
            //IList<string> getEmail = File.ReadAllLines(this._path);
            int start = 0,end;
            string content;
            for (int i = 0; i < get.Length; i++)
            {
                if (get[i].Equals(target))
                {
                    //end = (get[start]+get[i]);
                    //content = get[start,end];
                    //saveEmail.Append(content);
                }
            }
            return saveEmail;

        }

        public IList<string> Filter(IEnumerable<string> emails)
        {
            IList<string> result = new List<string>();
            foreach (var item in emails)
            {
                if (!result.Contains(item.Trim()))
                {
                    result.Add(item.Trim());
                }
            }
            return result;
        }

        public string[] Write(string path, IEnumerable<string> emails)
        {
            //StreamWriter writer = emails;
            throw new Exception();
        }
    }
}
