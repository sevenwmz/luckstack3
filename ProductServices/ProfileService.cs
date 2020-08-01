using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViewModel.Profile;
using Profile = EntityMVC.Profile;
using RepositoryMVC;

namespace ProductServices
{
    public class ProfileService : BaceService
    {
        /// <summary>
        /// Add UserInfo to db
        /// </summary>
        /// <param name="model">Need user Info</param>
        public int SaveUserInfo(WriteModel model)
        {
            Profile profile = Mapper.Map<Profile>(model);
            profile.BornTime = $"{model.YearId}年{model.MonthId}月";
            profile.Owner = CurrenUser;

            KeywordRepository repo = new KeywordRepository(dbContext);
            profile.keyword = new List<ProfileToKeyword>();
            if (model.FristKeywordName!= null)
            {
                profile.keyword.Add(new ProfileToKeyword { Profile = profile, Keyword = repo.FindKeyword(model.FristKeywordName) });
            }
            if (model.ScendKeywordName != null)
            {
                profile.keyword.Add(new ProfileToKeyword { Profile = profile, Keyword = repo.FindKeyword(model.ScendKeywordName) });
            }
            if (model.NeedSubKeyword != null)
            {
                Keywords checkExist = new Keywords();
                foreach (var item in new Keywords().GetKeywordList(model.NeedSubKeyword))
                {
                    checkExist = repo.FindKeyword(item.Name);
                    if (checkExist == null)
                    {
                        profile.keyword.Add(new ProfileToKeyword { Profile = profile, Keyword = new Keywords { Name = item.Name, Used = 1 } });
                    }
                    else
                    {
                        checkExist.Used += 1;
                        profile.keyword.Add(new ProfileToKeyword { Profile = profile, Keyword = checkExist });
                    }
                }
            }

            return new ProfileRepository(dbContext).AddUserInfo(profile);
        }
    }
}
