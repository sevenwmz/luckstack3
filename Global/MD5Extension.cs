using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
    public static class MD5Extension
    {
        public static string Md5Encrypt(this string sourec)
        {
            byte[] temp = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(sourec + Const.MD5ENCRYPT));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                builder.Append(temp[i].ToString("x2"));
            }

            Encoding.UTF8.GetString(temp);
            return builder.ToString();
        }
    }
}
