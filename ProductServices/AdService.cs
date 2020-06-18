using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices
{
    public class AdService : BaceService
    {
        public int Add(string contentOfAd, string webSite)
        {
            AD aD = new AD
            {
                ContentOfAd = contentOfAd,
                WebSite = webSite
            };
            aD = aD.PublishAd(aD);

            return new ADRepository().AddADToDatabase(aD);
        }
    }
}
