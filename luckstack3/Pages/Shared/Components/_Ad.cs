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
    public class _AdModel :ViewComponent
    {
        public IList<Ad> Ad { set; get; }
        private AdRepository _repository;

        public _AdModel()
        {
            _repository = new AdRepository();
        }

        public IViewComponentResult Invoke()
        {
            Ad = _repository.Get();
            return View("/Pages/Shared/_Ad.cshtml", Ad);
        }
    }
}