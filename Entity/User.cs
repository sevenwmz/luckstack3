using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Entity
{
    public class User
    {


        #region 设计一种方式，保证： 每一个User对象一定有Name和Password赋值
        public User()
        {

        }
        public User(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
        #endregion



        #region  Filed and properties


        [Required(ErrorMessage = "* 用户名不能为空")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "* 最大长度不能超过6")]
        [Display(Name = "* 用户名")]
        public string UserName { set; get; }



        #region 1.user.Password在类的外部只能改不能读( Secend Day )
        public int Id { set; get; }

        [Required(ErrorMessage = "* 中间性别？？？")]
        public string Gender { set; get; }
        public string Level { set; get; }

        [Required(ErrorMessage = "* Email不能为空")]
        [EmailAddress(ErrorMessage = "* 请输入有效Email")]
        public string Email { set; get; }

        [DataType(DataType.Password)]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(/*AllowEmptyStrings = true, */ErrorMessage = "* 密码不能为空")]
        public string Password { set; get; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password) , ErrorMessage = "* 两次密码输入不一致")]
        public string PasswordAgain { set; get; }


        #endregion
        public string NickName { set; get; }

        //积分
        public int Integral { set; get; }
        public string Birthday { set; get; }
        public string Constellation { set; get; }

        public TokenManager Manager { set; get; }
        //Password confirm.
        //Verification Code

        [Required(ErrorMessage = "* 少写一点点嘛......")]
        public string SelfIntroduction { set; get; }

        public int HelpBean { set; get; }

        public int HelpCredit { set; get; }
        public int HelpMoney { internal set; get; }
        #endregion



    }

    [HelpMoneyChanged(2, AttributeTargets.Method)]
    public class HelpMoneyChangedAttribute : Attribute
    {
        ///1.该特性只能用于方法
        ///2.有一个构造函数，可以接受一个int类型的参数amount，表示帮帮币变化的数量
        ///3.有一个string类型的Message属性，记录帮帮币变化的原因
        private int _helpMoneyAmount;

        public string Message { set; get; }
        private readonly AttributeTargets _attributeTarget;
        public HelpMoneyChangedAttribute(int amount, AttributeTargets validOn)
        {
            _attributeTarget = AttributeTargets.Method;//我源代码里面看是这样写一行，我就抄过来了，不知道对不对。
            _helpMoneyAmount = amount;
        }

    }

    public class GetPublish
    {
        public static void GetHM(object Money)
        {   //这里获取HelpMoneyChangedAttribute的附着和上面是否有内容
            var MoneyOnPublish =
                HelpMoneyChangedAttribute.GetCustomAttribute
                (Money.GetType(), typeof(HelpMoneyChangedAttribute));

            //这里获得HelpMoneyChangedAttribute里面的内容   顺便说一下，我也不知道这么写是不是对的，
            //但是外部只能获得public的内容，我想把私有的也搞出来试试看.
            //如果下面的写错了，那就哈哈哈哈。。。辣眼睛的屎山
            HelpMoneyChangedAttribute Frist = new HelpMoneyChangedAttribute(2, AttributeTargets.Method);
            Type Secend = typeof(HelpMoneyChangedAttribute);
            FieldInfo Third = Secend.GetField("_helpMoneyAmount",
                BindingFlags.NonPublic | BindingFlags.Instance);
            object Get_helpMoneyAmount = Third.GetValue(Frist);

            if (MoneyOnPublish != null)
            {
                HelpMoneyChangedAttribute change = MoneyOnPublish as HelpMoneyChangedAttribute;
                Console.WriteLine($"Message is:{change.Message},{change.TypeId}");
                Console.Write(Get_helpMoneyAmount);
                return;
            }
            Console.WriteLine("No flag");
        }
    }



}
