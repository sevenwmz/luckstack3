using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class KeywordController : Controller
    {
        public KeywordsService _repo;
        public KeywordController()
        {
            _repo = new KeywordsService();
        }


        // GET: _SecendKeyword
        public ActionResult _SecendKeywordItem(int fristKeywordId)
        {
            int[] fristKeyArr = new int[] { 41, 42, 43, 44 };
            if (!fristKeyArr.Contains(fristKeywordId))
            {
                throw new ArgumentException("Argument is not frist keyword,please cheack again");
            }
            return View(_repo.GetSecendKeywordBy(fristKeywordId));
        }
    }
}