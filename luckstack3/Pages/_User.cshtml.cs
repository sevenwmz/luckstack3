using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class _UserModel : PageModel
    {
        public int Id { set; get; } 

        public string Name { set; get; } 

        public int Level { set; get; }

    }
}