using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class UserRepository
    {
        /// <summary>
        /// Private Connect Proprety
        /// </summary>
        private MvcRepository repository;

        public UserRepository()
        {
            repository = new MvcRepository();
        }

        /// <summary>
        /// Get Inviter From Database
        /// </summary>
        /// <param name="name">Need Inviter Name</param>
        /// <returns>Return inviterInfo</returns>
        public User GetBy(string name)
        {
            //User user = new User();
            User user = repository.UsersInfo.Where(u => u.UserName == name).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Add data to database.
        /// </summary>
        /// <param name="regiserInfo">Need userInfo</param>
        public int AddRegisterToDatabase(User regiserInfo)
        {
            repository.UsersInfo.Add(regiserInfo);
            repository.SaveChanges();
            return repository.UsersInfo.Where(u => u.UserName == regiserInfo.UserName).SingleOrDefault().Id;
        }

        /// <summary>
        /// Add register all info ,inclund award and give inviter prize.
        /// </summary>
        /// <param name="regiserInfo">Need userInfo</param>
        public int Register(User info)
        {
            BMoney award = new BMoney();
            award = award.RegisterAwardBMoney();
            award.OwnerId = info.Id;

            info.Level = 0;
            info.Wallet = new List<BMoney>();
            info.Wallet.Add(award);
            int userId = AddRegisterToDatabase(info);

            //Give Inviter Bmoney prize.
            award = award.GiveInviterPrize(info.Inviter);
            new BMoneyRepository().AddNewRow(award);
            return userId;
        }



    }
}
