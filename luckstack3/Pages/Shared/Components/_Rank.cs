using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _17bang.Repository;

namespace _17bang
{
    public class _RankModel : ViewComponent
    {
        public IList<User> UsersRank { set; get; }

        private UserRepository _repository;

        public _RankModel()
        {
            _repository = new UserRepository();
        }

        public IViewComponentResult Invoke()
        {
            UsersRank = _repository.Get();
            return View(UsersRank);
        }
    }
}