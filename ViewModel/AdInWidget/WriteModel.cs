using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.AdInWidget
{
    public class WriteModel
    {
        public int Id { set; get; }
        public string AllSelectDate { set; get; }
        public bool HasNewAd { set; get; }
        public int? ChoosAd { set; get; }
        public string ContentOfAd { set; get; }
        public string WebSite { set; get; }
    }
}
