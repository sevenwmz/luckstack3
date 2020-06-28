using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViewModel.Profile;
using Profile = EntityMVC.Profile;

namespace ProductServices
{
    public class ProfileService : BaceService
    {
        /// <summary>
        /// Add UserInfo to db
        /// </summary>
        /// <param name="model">Need user Info</param>
        public void SaveUserInfo(WriteModel model)
        {
            Profile profile = connectedMapper.Map<Profile>(model);






        }
    }
}
