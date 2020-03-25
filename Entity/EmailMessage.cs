using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class EmailMessage : ISendMessage, IChat
    {
        void IChat.Send()
        {
            Console.WriteLine("send");
        }

        void ISendMessage.Send()
        {
            Console.WriteLine("send");
        }
    }
}
