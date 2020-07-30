using AutoMapper;
using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V = ViewModel;
using System.Web;
using RepositoryMVC;
using System.Data.Entity;
using Profile = EntityMVC.Profile;

namespace ProductServices
{
    public class BaceService
    {
        public UserRepository UserRepository;
        public BaceService()
        {
            UserRepository = new UserRepository(dbContext);
        }

        private static MapperConfiguration mapper;
        static BaceService()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                #region Comments Area
                cfg.CreateMap<V.ChildAction.ChildCommentModel,Comments>(MemberList.None)
                        .ReverseMap()
                         ;

                cfg.CreateMap<V.ChildAction.ChildCommentItem, Comments>(MemberList.None)
                        .ReverseMap()
                         ;

                #endregion

                #region ChatRoom Area
                cfg.CreateMap<V.ChildAction.ChatRoomModel,Chat>(MemberList.None)
                        .ReverseMap()
                         ;

                cfg.CreateMap<V.ChildAction.ChatItemModel, Chat>(MemberList.None)
                        .ReverseMap()
                         ;

                cfg.CreateMap<V.ChildAction.UserModel, User>(MemberList.None)
                        .ForMember(u=>u.UserName,opt=>opt.MapFrom(c=>c.Author))                            
                        .ForMember(u=>u.Id,opt=>opt.MapFrom(c=>c.AuthorId))
                        .ReverseMap()
                         ;

                #endregion

                #region ChildSeries Area
                cfg.CreateMap<V.ChildAction.ChildCategoryInsideSeriesModel, Series>(MemberList.None)
                        .ForMember(s => s.ContentOfSeries, opt => opt.MapFrom(s => s.Title))
                        .ForMember(s => s.Summary, opt => opt.MapFrom(s => s.Summary))
                        .ReverseMap()
                        .ForMember(s => s.Title, opt => opt.MapFrom(s => s.ContentOfSeries))
                        ;

                cfg.CreateMap<V.ChildAction.ChildCategorySeriesModel, Series>(MemberList.None)
                        .ForMember(s => s.ContentOfSeries, opt => opt.MapFrom(s => s.ChildSeries.Select(m => m.Title)))
                        .ForMember(s => s.Summary, opt => opt.MapFrom(s => s.ChildSeries.Select(m => m.Summary)))
                        .ReverseMap()
                        .ForMember(s => s.Title , opt=>opt.MapFrom(s=>s.ContentOfSeries))
                        ;


                cfg.CreateMap<V.ChildAction.ChildSeriesModel, Series>(MemberList.None)
                        .ForMember(s => s.ContentOfSeries, opt => opt.MapFrom(s => s.Title))
                        .ReverseMap()
                        .ForMember(s => s.AuthorId, opt => opt.MapFrom(s => s.Owner.Id))
                        .ForMember(s => s.AuthorName, opt => opt.MapFrom(s => s.Owner.UserName))
                        ;
                #endregion

                #region MessageMine
                cfg.CreateMap<MessageMine, V.Message.MineModel>(MemberList.None)
                        .ReverseMap()
                        .ForMember(m => m.OwnerId, opt => opt.Ignore())
                        .ForMember(m => m.Owner, opt => opt.Ignore())
                        ;
                #endregion

                #region Profile 
                cfg.CreateMap<V.Profile.WriteModel, Profile>(MemberList.None)
                        .ForMember(p => p.Constellation, opt => opt.MapFrom(p => p.ConstellationName))
                        .ReverseMap()
                        .ForMember(p => p.NeedSubKeyword, opt => opt.Ignore())
                        .ForMember(p => p.FristKeyword, opt => opt.Ignore())
                        .ForMember(p => p.FristKeywordName, opt => opt.Ignore())

                        ;
                #endregion

                #region MoneyTrade and BMoney
                cfg.CreateMap<V.MoneyTrade.SaleModel, BMoney>(MemberList.None)
                        .ReverseMap()
                        .ForMember(m => m.ByFrom, opt => opt.Ignore())
                        .ForMember(m => m.SaleCount, opt => opt.MapFrom(b => b.Change))
                        .ForMember(m => m.Message, opt => opt.MapFrom(b => b.Detail))
                        .ForMember(m => m.TotalSaleMoney, opt => opt.Ignore())
                        .ForMember(m => m.LeftBMoney, opt => opt.MapFrom(b => b.LeftBMoney + b.Freezing))
                        .ForMember(m => m.CanSale, opt => opt.MapFrom(b => b.LeftBMoney))
                        ;

                #endregion

                #region ChangePassword
                cfg.CreateMap<V.Password.ChangeModel, User>(MemberList.None)
                    .ReverseMap()
                    .ForMember(p => p.NewPwd, opt => opt.MapFrom(u => u.Password))
                    .ForMember(p => p.ConfrimPwd, opt => opt.Ignore())
                    .ForMember(p => p.OldPwd, opt => opt.Ignore())
                 ;
                cfg.CreateMap<V.Password.ForgetModel, User>(MemberList.None)
                    .ForMember(u => u.EmailAddress, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(f => f.UserName, opt => opt.MapFrom(u => u.UserName))
                    .ForMember(f => f.Captcha, opt => opt.Ignore())
                    ;



                #endregion

                #region Contact Area
                cfg.CreateMap<Contact, V.Contact.ContactModel>(MemberList.None)
                    .ReverseMap()
                    ;

                cfg.CreateMap<V.Contact.ContactModel, Contact>(MemberList.None)
                    .ReverseMap()
                    .ForMember(c => c.Email, opt => opt.MapFrom(c => c.Owner.EmailAddress.Address))
                    ;
                #endregion

                #region ChildAD Area
                cfg.CreateMap<V.ChildAction.ChildADModel, AD>(MemberList.None)
                    .ReverseMap()
                    ;
                #endregion

                #region ChildRank Area
                cfg.CreateMap<V.ChildAction.ChildRankModel, User>(MemberList.None)
                    .ReverseMap()
                    .ForMember(u => u.BMoney, opt => opt.MapFrom(u => u.Wallet.OrderByDescending(m => m.Latestime).FirstOrDefault().LeftBMoney))
                    ;
                #endregion

                #region Problem Area
                cfg.CreateMap<V.Problem.ProblemSingleModel, Problem>(MemberList.None)
                    .ForMember(p => p.NeedRemoteHelp, opt => opt.Ignore())
                    .ForMember(p => p.RewardMoney, opt => opt.Ignore())
                    .ForMember(p => p.Status, opt => opt.MapFrom(p => p.Status))
                    .ForMember(p => p.HelpFrom, opt => opt.Ignore())
                    .ForMember(p => p.Author, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(p => p.Author, opt => opt.MapFrom(p => p.Author.UserName))
                    .ForMember(p => p.Level, opt => opt.MapFrom(p => p.Author.Level))
                    .ForMember(p => p.Answer, opt => opt.Ignore())
                    .ForMember(p => p.Summarize, opt => opt.Ignore())
                    .ForMember(p => p.Keywords, opt => opt.MapFrom(p => p.OwnKeyword.Select(o => o.Keyword)))
                    ;




                cfg.CreateMap<V.Problem.ProblemItemModel, Problem>(MemberList.None)
                    .ForMember(p => p.Id, opt => opt.MapFrom(p => p.ProblemId))
                    .ForMember(p => p.NeedRemoteHelp, opt => opt.Ignore())
                    .ForMember(p => p.RewardMoney, opt => opt.Ignore())
                    .ForMember(p => p.Status, opt => opt.MapFrom(p => p.Status))
                    .ForMember(p => p.HelpFrom, opt => opt.Ignore())
                    .ForMember(p => p.Author, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(p => p.Author, opt => opt.MapFrom(p => p.Author.UserName))
                    .ForMember(p => p.AuthorId, opt => opt.MapFrom(p => p.Author.Id))
                    .ForMember(p => p.Summary, opt => opt.Ignore())
                    .ForMember(p => p.ListKeywords, opt => opt.MapFrom(p => p.OwnKeyword.Select(o => o.Keyword)))
                    ;


                cfg.CreateMap<V.Problem.ProblemEditModel, Problem>(MemberList.None)
                   .ForMember(p => p.PublishTime, opt => opt.Ignore())
                   .ForMember(p => p.HelpFrom, opt => opt.Ignore())
                   .ReverseMap()
                   .ForMember(p => p.HelpFrom, opt => opt.Ignore())
                   .ForMember(p => p.HasLeftMoney, opt => opt.MapFrom(p => p.Author.Wallet.OrderByDescending(m => m.Latestime).Where(m => m.LeftBMoney > 0)))
                   .ForMember(p => p.FristDropDownKeywords, opt => opt.Ignore())
                   .ForMember(p => p.SecendDropDownKeywords, opt => opt.Ignore())
                   .ForMember(p => p.NeedSubKeyword, opt => opt.Ignore())
                   .ForMember(p => p.HasLeftMoney, opt => opt.Ignore())
                   .ForMember(p => p.Keywords, opt => opt.Ignore())
                   .ForMember(p => p.RewardMoney, opt => opt.Ignore())
                   ;


                cfg.CreateMap<Problem, V.Problem.ProblemNewModel>(MemberList.None)
                   .ForMember(p => p.FristDropDownKeywords, opt => opt.Ignore())
                   .ForMember(p => p.SecendDropDownKeywords, opt => opt.Ignore())
                   .ForMember(p => p.NeedSubKeyword, opt => opt.Ignore())
                   .ForMember(p => p.HasLeftMoney, opt => opt.Ignore())
                   .ForMember(p => p.HelpFrom, opt => opt.Ignore())
                   .ForMember(p => p.Id, opt => opt.Ignore())
                   .ForMember(p => p.Keywords, opt => opt.Ignore())
                   .ReverseMap()
                   .ForMember(p => p.Id, opt => opt.Ignore())
                   .ForMember(p => p.OwnKeyword, opt => opt.Ignore())
                   .ForMember(p => p.PublishTime, opt => opt.Ignore())
                   .ForMember(p => p.HelpFrom, opt => opt.Ignore())
                   ;
                #endregion

                #region User Area
                cfg.CreateMap<User, V.RegisterModel>()
                    .ForMember(r => r.PasswordAgain, opt => opt.Ignore())
                    .ForMember(r => r.Captcha, opt => opt.Ignore())
                    .ForMember(r => r.CookieId, opt => opt.Ignore())
                    .ForMember(r => r.Inviter, opt => opt.Ignore())
                    .ForMember(r => r.InviterNumber, opt => opt.MapFrom(r => r.MyInviterNumber))
                    .ReverseMap()
                    .ForMember(r => r.Inviter, opt => opt.Ignore())
                    ;
                cfg.CreateMap<User, V.Log.OnModel>()
                    .ForMember(l => l.LogInName, opt => opt.MapFrom(l => l.UserName))
                    .ForMember(l => l.Captcha, opt => opt.Ignore())
                    .ForMember(l => l.RemenberMe, opt => opt.Ignore())
                    .ReverseMap()
                    ;
                #endregion

                #region Article Area
                cfg.CreateMap<Article, V.Article.ArticleCategoryModel>(MemberList.None)
                    .ForMember(a => a.ListKeyword, opt => opt.MapFrom(a => a.OwnKeyword.Select(o => o.Keyword)))
                    .ForMember(a => a.Author, opt => opt.MapFrom(a => a.Author.UserName))
                    .ForMember(a => a.AuthorId, opt => opt.MapFrom(a => a.Author.Id))
                    .ForMember(a => a.Level, opt => opt.MapFrom(a => a.Author.Level))
                    .ForMember(a => a.CategoryId, opt => opt.MapFrom(a => a.UseSeries.Id))
                    .ForMember(a => a.CategoryTitle, opt => opt.MapFrom(a => a.UseSeries.ContentOfSeries))
                    .ForMember(a => a.CategorySummary, opt => opt.MapFrom(a => a.UseSeries.Summary))
                    .ReverseMap()
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    .ForMember(a => a.OwnKeyword, opt => opt.Ignore())
                    .ForMember(a => a.UseSeries, opt => opt.Ignore())
                    .ForMember(a => a.UseAd, opt => opt.Ignore())
                    ;



                cfg.CreateMap<Article, V.Article.AritcleAuthorModel>(MemberList.None)
                    .ForMember(a => a.ListKeyword, opt => opt.MapFrom(a => a.OwnKeyword.Select(o => o.Keyword)))
                    .ForMember(a => a.Author, opt => opt.MapFrom(a => a.Author.UserName))
                    .ForMember(a => a.AuthorId, opt => opt.MapFrom(a => a.Author.Id))
                    .ForMember(a => a.Level, opt => opt.MapFrom(a => a.Author.Level))
                    .ReverseMap()
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    .ForMember(a => a.OwnKeyword, opt => opt.Ignore())
                    .ForMember(a => a.UseSeries, opt => opt.Ignore())
                    .ForMember(a => a.UseAd, opt => opt.Ignore())
                    ;



                cfg.CreateMap<V.Article.ArticleSingleModel, Article>(MemberList.None)
                    .ForMember(a => a.Summary, opt => opt.Ignore())
                    .ForMember(a => a.UseAd, opt => opt.Ignore())
                    .ForMember(a => a.UseADId, opt => opt.Ignore())
                    .ForMember(a => a.UseSeriesId, opt => opt.Ignore())
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(a => a.Keywords, opt => opt.MapFrom(a => a.OwnKeyword.Select(o => o.Keyword)))
                    .ForMember(a => a.Author, opt => opt.MapFrom(a => a.Author.UserName))
                    .ForMember(a => a.ChoosSeries, opt => opt.MapFrom(a => a.UseSeries.ContentOfSeries))
                    .ForMember(a => a.Comments, opt => opt.Ignore())
                    ;

                cfg.CreateMap<Article, V.ArticleItemsModel>(MemberList.None)
                    .ForMember(a => a.ListKeyword, opt => opt.MapFrom(a => a.OwnKeyword.Select(o => o.Keyword)))
                    .ForMember(a => a.Author, opt => opt.MapFrom(a => a.Author.UserName))
                    .ForMember(a => a.AuthorId, opt => opt.MapFrom(a => a.Author.Id))
                    .ForMember(a => a.Level, opt => opt.MapFrom(a => a.Author.Level))

                    .ReverseMap()
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    .ForMember(a => a.OwnKeyword, opt => opt.Ignore())
                    .ForMember(a => a.UseSeries, opt => opt.Ignore())
                    .ForMember(a => a.UseAd, opt => opt.Ignore())
                    ;

                cfg.CreateMap<Article, V.ArticleNewModel>(MemberList.None)
                   .ForMember(a => a.ChoosAd, opt => opt.MapFrom(p => p.UseADId))
                   .ForMember(a => a.ChoosSeries, opt => opt.MapFrom(p => p.UseSeriesId))
                   .ForMember(a => a.ContentOfAd, opt => opt.Ignore())
                   .ForMember(a => a.WebSite, opt => opt.Ignore())
                   .ForMember(a => a.Series, opt => opt.Ignore())
                   .ForMember(a => a.Ad, opt => opt.Ignore())
                   .ForMember(a => a.Author, opt => opt.Ignore())
                   .ForMember(a => a.HasNewAd, opt => opt.Ignore())
                   .ForMember(a => a.Keywords, opt => opt.Ignore())
                   .ReverseMap()
                   .ForMember(a => a.Author, opt => opt.Ignore())
                   ;


                cfg.CreateMap<Article, V.Article.AritcleEditModel>(MemberList.None)
                    .ForMember(a => a.ChoosAd, opt => opt.MapFrom(p => p.UseADId))
                    .ForMember(a => a.ChoosSeries, opt => opt.MapFrom(p => p.UseSeriesId))
                    .ForMember(a => a.ContentOfAd, opt => opt.MapFrom(a => a.UseAd.ContentOfAd))
                    .ForMember(a => a.PublishTime, opt => opt.Ignore())
                    .ForMember(a => a.WebSite, opt => opt.MapFrom(a => a.UseAd.WebSite))
                    .ForMember(a => a.Series, opt => opt.Ignore())
                    .ForMember(a => a.Ad, opt => opt.Ignore())
                    .ForMember(a => a.Author, opt => opt.MapFrom(a => a.Author.UserName))
                    .ForMember(a => a.HasNewAd, opt => opt.Ignore())
                    .ForMember(a => a.Keywords, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    .ForMember(a => a.PublishTime, opt => opt.Ignore())
                    ;


                #endregion

                #region Keyword Area
                cfg.CreateMap<Keywords, V.KeywordModel>(MemberList.None)
                    .ReverseMap()
                    .ForMember(k => k.UseArticle, opt => opt.Ignore())
                    .ForMember(k => k.Level, opt => opt.Ignore())
                    .ForMember(k => k.LevelId, opt => opt.Ignore())
                    ;
                #endregion

            });
#if DEBUG
            mapper.AssertConfigurationIsValid();
#endif
        }

        private const string COOKIE_NAME = "SevenMarkLogIn";
        public int? CurrentUserId
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[COOKIE_NAME];
                if (cookie == null)
                {
                    return null;
                }
                string id = cookie.Values["id"];
                string pwd = cookie.Values["pwd"];

                User current = UserRepository.Find(Convert.ToInt32(id));

                if (current.Password != pwd)
                {
                    throw new ArgumentException("你的信息有点点问题呀,我们攻城狮已经记录在册,并解决这个问题呦！");
                }
                return Convert.ToInt32(id);
            }
        }

        public User CurrenUser
        {
            get => UserRepository.Find(CurrentUserId.Value);
        }

        public SqlContext dbContext
        {
            get
            {
                SqlContext context = HttpContext.Current.Items["dbContext"] as SqlContext;
                if (context == null)
                {
                    context = new SqlContext();
                    context.Database.BeginTransaction();
                    HttpContext.Current.Items["dbContext"] = context;
                }//else nothing;
                return context;
            }
        }
        public void Commit()
        {
            using (SqlContext context = HttpContext.Current.Items["dbContext"] as SqlContext)
            {
                if (context != null)
                {
                    using (DbContextTransaction transaction = context.Database.CurrentTransaction)
                    {
                        try
                        {
                            context.SaveChanges();
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
        }
        public void RollBack()
        {
            using (SqlContext context = HttpContext.Current.Items["dbContext"] as SqlContext)
            {
                using (DbContextTransaction transaction = context.Database.CurrentTransaction)
                {
                    transaction.Rollback();
                }
            }
        }

        protected IMapper connectedMapper
        {
            get => mapper.CreateMapper();
        }

        public void ClearContext()
        {
            HttpContext.Current.Items["dbContext"] = null;
        }


    }
}
