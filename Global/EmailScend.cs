using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Global
{
    public class EmailScend
    {
        //I love static!!!!!!!
        public static int SecendEmail(EmailModel model, string subject = "激活Email", string body = null)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("feige_20200214@163.com");
            mail.To.Add(model.EmailAddress);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            int valideCode = new Random().Next(1111, 9999);

            if (body == null)
            {
                body = $@"感谢查询,{model.UserName},现在验证你的邮箱地址：你的验证码是{valideCode},
                                也可以点击链接跳转修改密码(如浏览器不支持，请复制下面链接到地址栏) 
                                http://localhost:51543/Password/Reset/code={valideCode}?email={model.EmailAddress}";
            }
            mail.Body = body;

            SmtpClient client = new SmtpClient("smtp.163.com");
            client.Port = 25;
            client.Credentials = new System.Net.NetworkCredential("feige_20200214@163.com", "yz17bang");
            client.EnableSsl = false;


            client.Send(mail);

            return valideCode;
            ///here need attach db expair time. later

        }
    }
}
