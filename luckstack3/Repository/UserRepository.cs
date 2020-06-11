using Entity;
using luckstack3;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Repository
{
    public class UserRepository
    {
        private static IList<User> _users { set; get; }

        static UserRepository()
        {
            _users = new List<User>
            {
                new User{UserName = "王胖子",Password = "1234",Level = "9",Integral = 999},
                new User{UserName = "阿泰",Password = "1234",Level = "8",Integral = 499},
                new User{UserName = "叶飞",Password = "1234",Level = "3",Integral = 929},
                new User{UserName = "老刘",Password = "1234",Level = "5",Integral = 429},
                new User{UserName = "欧阳",Password = "1234",Level = "4",Integral = 339},
                new User{UserName = "wpzwpz",Password = "1234",Level = "7",Integral = 339},
                new User{UserName = "freefly",Password = "1234",Level = "1",Integral = 339},
                new User{UserName = "老王",Password = "1234",Level = "10",Integral = 339},
            };
        }

        /// <summary>
        /// Save Register To Database
        /// </summary>
        /// <param name="user">Need user Info</param>
        public bool Save(User user)
        {
            DBHelper helper = new DBHelper();
            #region Insert Register
            string cmd =
                @"Insert [User](InviteName,InvitedCode,UserName,[Password],InviteById,[Level])
                Values(@InviteName, @InvitedCode, @UserName, @Password,(Select Id From[User] Where UserName = @InviteName),1) ";
            int newRegisterId = helper.Insert(cmd, new SqlParameter[]
            {
                new SqlParameter("@InviteName",user.Inviter),
                new SqlParameter("@InvitedCode",user.InviterNumber),
                new SqlParameter("@UserName",user.UserName),
                new SqlParameter("@Password",user.Password)
            });
            #endregion

            #region Give New User 10 BMoney
            //Got newRegisterId From Identity ,is safe.
            string cmdForRegisterBMoney = $@"Insert HelpMoney(BmoneyId,BMoney,Detail,LatesTime) 
                                            Values(@OwnerId , 10, N'注册赠送10帮帮币', GetDate()) ";
            helper.Insert(cmdForRegisterBMoney,new SqlParameter[] { new SqlParameter("@OwnerId", newRegisterId) });
            #endregion

            #region Give Inviter 10 Award
            AwardToInviter(user.Inviter);
            #endregion

            return true;
        }

        /// <summary>
        /// LogOn Verify
        /// </summary>
        /// <param name="logOn">Need LogOn Info</param>
        /// <returns></returns>
        internal bool VerifyLogIn(LogOnModel logOn)
        {
            using (DbConnection connection = new DBHelper().Connection)
            {
                using (DbCommand sqlCheckUser = new SqlCommand(
                    @"select UserName,Password from [User] where Password = @Password and UserName = @Name ", (SqlConnection)connection))
                {
                    sqlCheckUser.Parameters.AddRange(new DbParameter[] { new SqlParameter("@Name", logOn.Name), new SqlParameter("@Password", logOn.Password) });
                    connection.Open();
                    SqlDataReader reader = (SqlDataReader)sqlCheckUser.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        return false;
                    }

                    while (reader.Read())
                    {
                        if ((reader["UserName"].ToString()).Trim() != logOn.Name)
                        {
                            return false;
                        }
                        if ((reader["Password"].ToString()).Trim() != logOn.Password)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

        }

        #region Register Save Function
        /// <summary>
        /// Check username has repeat
        /// </summary>
        /// <param name="userName">Need username</param>
        /// <returns></returns>
        public bool UserNameHasRepeat(string userName)
        {
            string cmd = @"Select UserName From [User] Where UserName = @UserName";
            if (new DBHelper().ExcuteScalar(cmd, new SqlParameter("@UserName", userName)) == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check InviteCode is correct
        /// </summary>
        /// <param name="inviterNumber">Need inviterCode</param>
        /// <returns></returns>
        public bool CheckInviteCode(string inviterNumber)
        {
            string cmd = @"Select InvitedCode From [User] Where InvitedCode = @InviteCode";
            if (new DBHelper().ExcuteScalar(cmd, new SqlParameter("@InviteCode", inviterNumber)) == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check InviteName is correct
        /// </summary>
        /// <param name="inviter">Need Inviter</param>
        /// <returns></returns>
        public bool CheckInvitedName(string inviter)
        {
            string cmd = @"Select UserName From[User] Where UserName = @Inviter";
            if (new DBHelper().ExcuteScalar(cmd, new SqlParameter("@Inviter", inviter)) == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Give inviter gift 10 BMoney
        /// </summary>
        /// <param name="inviter">Need inviter name</param>
        internal void AwardToInviter(string inviter)
        {
            using (DbConnection connection = new DBHelper().Connection)
            {
                string cmdOfBmoney = @"Insert HelpMoney(BmoneyId,BMoney,Detail,LatesTime) 
                                    Values(
                                    (Select Id From [User] Where UserName = @InviteName) ,
                                    (Select (Select Top 1 BMoney From HelpMoney Where BMoneyId = (Select Id From [User] Where UserName = @InviteName)order by LatesTime desc)+10),
                                    N'邀请成功赠送10帮帮币',
                                    GetDate()) ";
                DbCommand command = new SqlCommand(cmdOfBmoney, (SqlConnection)connection);
                connection.Open();
                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        command.Transaction = transaction;
                        command.Parameters.Add(new SqlParameter("@InviteName", inviter));
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion
        public IList<User> Get()
        {
            return _users;
        }
        public User GetByName(string userName)
        {
            return _users.Where(u => u.UserName == userName).SingleOrDefault();
        }
    }
}
