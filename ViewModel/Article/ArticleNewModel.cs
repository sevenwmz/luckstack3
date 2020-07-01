using EntityMVC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel
{
    public class ArticleNewModel
    {
        public int Id { set; get; }
        public string Author { set; get; }

        [Required(ErrorMessage = "标题不能为空")]
        public string Title { set; get; }

        [Required(ErrorMessage = "内容不能为空")]
        [AllowHtml]
        public string Body { set; get; }

        public string Summary { set; get; }

        public DateTime PublishTime { get; set; }

        public string Keywords { set; get; }

        public int? ChoosSeries { set; get; }
        public IList<SelectListItem> Series { set; get; }

        public int? ChoosAd { set; get; }
        public IList<SelectListItem> Ad { set; get; }

        public string ContentOfAd { set; get; }

        public string WebSite { set; get; }
        [Display(Name = "修改")]
        public bool HasNewAd { set; get; }
    }
}
