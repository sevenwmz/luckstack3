using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel.Profile
{
    public class WriteModel
    {
        public bool Gender { set; get; }

        public string NeedSubKeyword { set; get; }
        [StringLength(255)]
        public string SelfIntroduce { set; get; }

        public int YearId { set; get; }
        public IList<SelectListItem> Year { set; get; }
        public int MonthId { set; get; }
        public IList<SelectListItem> Month { set; get; }
        public string ConstellationName { set; get; }
        public string FristKeywordId { set; get; }
        public IList<SelectListItem> FristKeyword { set; get; }
        public string ScendKeywordId { set; get; }
        public IList<SelectListItem> ScendKeyword { set; get; }
    }
}
