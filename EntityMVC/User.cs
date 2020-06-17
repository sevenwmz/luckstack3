using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class User : BaceEntity
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public int Level { set; get; }
        public int? InviterId { set; get; }
        public User Inviter { set; get; }
        public int MyInviterNumber { set; get; }
        public IList<BMoney> Wallet { set; get; }

        /// <summary>
        /// Add register all info ,inclund award and give inviter prize.
        /// </summary>
        /// <param name="regiserInfo">Need userInfo</param>
        public User Register(User user, BMoney award)
        {
            award.OwnerId = user.Id;
            user.Level = 0;
            user.Wallet = new List<BMoney>();
            user.Wallet.Add(award);
            user.MyInviterNumber = getRandomInviterNumber();
            return user;
        }

        /// <summary>
        /// Get Inviter Random Number
        /// </summary>
        /// <returns>Return 4 number</returns>
        private int getRandomInviterNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }

    }
}
