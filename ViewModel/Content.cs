using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class Content
    {
        public int Id { set; get; }

        public string Author { set; get; }

        [Required(ErrorMessage = "标题不能为空")]
        public string Title { set; get; }

        [Required(ErrorMessage = "内容不能为空")]
        public string Body { set; get; }

        public string Summary { set; get; }

        public DateTime PublishTime { get; set; }

        public string Keywords { set; get; }
    }
}
