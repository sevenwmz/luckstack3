using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ProductServices
{
    public class RegisterService : BaceService
    {
        /// <summary>
        /// Connection to userRepository
        /// </summary>
        private UserRepository _userRepository;

        public RegisterService()
        {
            _userRepository = new UserRepository(dbContext);
        }

        /// <summary>
        /// Get Name exist in database
        /// </summary>
        /// <param name="name">Need inviter name</param>
        /// <returns>Return one of RegisterModel Info</returns>
        public RegisterModel GetByName(string name)
        {
            User userInfo = _userRepository.GetBy(name);
            return Mapper.Map<RegisterModel>(userInfo);
        }

        /// <summary>
        /// Add award and constitute registerInfo ,add to reposiroty.
        /// </summary>
        /// <param name="user">Need registerInfo</param>
        public int Add(RegisterModel user)
        {
            User newUser = Mapper.Map<User>(user);

            BMoney award = new BMoney();
            award = award.RegisterAwardBMoney();

            newUser.Inviter = _userRepository.GetBy(user.Inviter);
            newUser = newUser.Register(newUser, award);
            int userId = _userRepository.AddRegisterToDatabase(newUser);

            //Give Inviter Bmoney prize.
            BMoneyRepository moneyRepository = new BMoneyRepository(dbContext);
            BMoney money = new BMoney();
            money = money.GiveInviterPrize(moneyRepository.GetByAuthorBMoney(newUser.InviterId));
            moneyRepository.AddNewRow(money);
            return userId;
        }
    }
}
