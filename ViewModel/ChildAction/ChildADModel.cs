using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel.ChildAction
{
    public class ChildADModel
    {
        public int Id { set; get; }
        [Display(Name = "修改")]
        public bool HasNewAd { set; get; }

        public int? ChoosAd { set; get; }
        public string ContentOfAd { set; get; }
        public string WebSite { set; get; }
        public IList<ChildADModel> Items { set; get; }
    }
}
