using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class User : BaceEntity
    {
        public string Inviter { set; get; }
        public string InviterNumber { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public int Level { set; get; }
        public IList<BMoney> Wallet { set; get; }




    }
}
