using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class NoticeModel : ViewComponent
    {
        public NoticeModel Nothing;
        public static bool ShowNotice;

        private NoticeRepository _noticeRepository;

        public NoticeModel()
        {
            _noticeRepository = new NoticeRepository();
        }
        public IList<Notice> Notices;

        public IViewComponentResult Invoke()
        {
            string hasCookie = HttpContext.Request.Cookies[Const.COOKIE_USER];
            ShowNotice = string.IsNullOrEmpty(hasCookie);

            Notices = _noticeRepository.Get();

            return View(Notices);
        }
    }
}