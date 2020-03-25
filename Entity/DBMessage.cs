using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class DBMessage : ISendMessage ,IChat
    {
        void IChat.Send()
        {
            Console.WriteLine("Send");
        }

        void ISendMessage.Send()
        {
            Console.WriteLine("Send");
        }
    }
}
