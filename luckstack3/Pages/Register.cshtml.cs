using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using _17bang;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace luckstack3
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        [Required(ErrorMessage = "* 邀请人不能为空")]
        public string Inviter { set; get; }

        [Required(ErrorMessage = "* 邀请码不能为空")]
        public string InviterNumber { set; get; }

        public string UserName { set; get; }

        public string Password { set; get; }

        public string PasswordAgain { set; get; }

        public string Captcha { set; get; }

        public int CookieId { set; get; }

        private UserRepository _userRepository;
        public RegisterModel()
        {
            _userRepository = new UserRepository();
        }

        public void OnGet()
        {
            ViewData["preRegister"] = Request.Query[Const.PREPAGE];
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User user = new User
            {
                Inviter = this.Inviter,
                InviterNumber = this.InviterNumber,
                UserName = this.UserName,
                Password = this.Password

            };

            _userRepository.Save(user);


            #region Old Funciton

            //using (DbConnection connection = new SqlConnection(connectionToDatabase))
            //{
            //    connection.Open();
            //    #region Prepare parameter 
            //    //For Invitername
            //    DbParameter pInviteName = new SqlParameter("@Inviter", Inviter);
            //    //For InviterNumber
            //    DbParameter pInviteNumber = new SqlParameter("@InviterNumber", InviterNumber);
            //    //For UserName
            //    DbParameter pUserName = new SqlParameter("@UserName", UserName);
            //    //For Password
            //    DbParameter pPassword = new SqlParameter("@Password", Password);
            //    #endregion

            //    #region Save Register
            //    using (
            //        DbCommand sqlRegister = new SqlCommand(
            //            //Add BMoney use for later.
            //            $"Declare @TempId Int = (Select Max(Id)+1 From HelpMoney) " +
            //            $"Insert HelpMoney(Id,BMoney,Detail) Values(@TempId,50,N'注册赠送50帮帮币') " +

            //            //Add new user.
            //            $"Insert[User](InviteName, InviteNumber, UserName,[Password], InviteById, BMoneyId)" +
            //            $"Values(" +
            //            $"(Select u.UserName From[User] u Where u.UserName = @Inviter )," +
            //            $"(Select u.InviteNumber From[User] u Where u.InviteNumber = @InviterNumber And u.UserName = @Inviter)," +
            //            $"@Username," +
            //            $"@Password," +
            //            $"(Select u.Id From[User] u Where u.InviteName = @Inviter)," +

            //            //Here I'm not sure about @@Identity.
            //            $"(Select Id From HelpMoney Where Id = @TempId) " +
            //            $") ", (SqlConnection)connection
            //            )
            //        )
            //    {
            //        sqlRegister.Parameters.AddRange(new DbParameter[] { pInviteName, pInviteNumber, pUserName, pPassword });
            //        sqlRegister.ExecuteNonQuery();
            //    }
            //    #endregion
            //}

            #endregion



            HttpContext.Session.SetString(Const.COOKIE_USER, Const.COOKIE_VALUE);
            Response.Cookies.Append(Const.COOKIE_USER, Const.COOKIE_VALUE);
            return Redirect(Request.Query[Const.PREPAGE]);
        }
    }
}