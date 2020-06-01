using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using _17bang;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace luckstack3
{
    [BindProperties]
    public class LogOnModel : PageModel
    {
        #region Fileds 
        [Required(ErrorMessage = "* 用户名不能为空")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "* 最大长度不能超过6")]
        [Display(Name = "* 用户名")]
        public string Name { set; get; }

        [DataType(DataType.Password)]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(/*AllowEmptyStrings = true, */ErrorMessage = "* 密码不能为空")]
        public string Password { set; get; }

        //private UserRepository _repository { set; get; }
        //public LogOnModel()
        //{
        //    _repository = new UserRepository();
        //}

        public bool RemenberMe { set; get; }

        public string Captcha { set; get; }

        //Best ideal , I can't delete it  /xyx
        public static bool IsLogIn { set; get; }
        #endregion

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            string checkUser = string.Empty;
            string checkPassword = string.Empty;



            //User user = _repository.GetByName(Name);

            //connection to database
            string connectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";
            using (DbConnection connection = new SqlConnection(connectionToDatabase))
            {
                connection.Open();
                #region Parameter of sqlCheckUser
                //For login name check 
                DbParameter pName = new SqlParameter("@Name", Name);
                //For login password check 
                DbParameter pPassword = new SqlParameter("@Password", Password);
                #endregion

                #region Main function of check userInfo exists
                using (
                        DbCommand sqlCheckUser = new SqlCommand(
                            $"select UserName,Password from [User] " +
                            $"where Password = @Password and UserName = @Name ", (SqlConnection)connection)
                        )
                {
                    sqlCheckUser.Parameters.AddRange(new DbParameter[] { pName, pPassword });
                    SqlDataReader reader = (SqlDataReader)sqlCheckUser.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        ModelState.AddModelError(nameof(Password), "用户名或密码不正确");
                        return Page();
                    }

                    while (reader.Read())
                    {
                        if ((reader["UserName"].ToString()).Trim() != Name)
                        {
                            ModelState.AddModelError(nameof(Name), "用户名不正确");
                            return Page();
                        }
                        if ((reader["Password"].ToString()).Trim() != Password)
                        {
                            ModelState.AddModelError(nameof(Password), "用户名或密码不正确");
                            return Page();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                #endregion

            }


            //Response.Cookies.Append(Name, (++_cookie).ToString());
            HttpContext.Session.SetString(Const.SESSION_USER, Const.SESSION_VALUE);
            if (RemenberMe)
            {
                Response.Cookies.Append(Const.COOKIE_USER, Const.COOKIE_VALUE);
                new CookieOptions { Expires = DateTime.Now.AddDays(90) };
            }

            //登陆传值
            IsLogIn = true;
            return Redirect(Request.Query[Const.PREPAGE]);

        }
    }
}