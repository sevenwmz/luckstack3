﻿using AutoMapper;
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

namespace ProductServices
{
    public class BaceService
    {
        private static MapperConfiguration mapper;
        static BaceService()
        {
            mapper = new MapperConfiguration(cfg =>
            {
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
                cfg.CreateMap<Article, V.ArticleNewModel>()
                    .ForMember(a => a.ChoosAd, opt => opt.Ignore())
                    .ForMember(a => a.ChoosSeries, opt => opt.Ignore())
                    .ForMember(a => a.ContentOfAd, opt => opt.Ignore())
                    .ForMember(a => a.WebSite, opt => opt.Ignore())
                    .ForMember(a => a.Series, opt => opt.Ignore())
                    .ForMember(a => a.Ad, opt => opt.Ignore())
                    .ForMember(a => a.Keywords, opt => opt.Ignore())
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    .ForMember(a => a.HasNewAd, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    ;

                cfg.CreateMap<Article, V.ArticleItemsModel>()
                    .ForMember(a => a.Keywords, opt => opt.Ignore())
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    .ForMember(a => a.OwnKeyword, opt => opt.Ignore())
                    .ForMember(a => a.UseSeries, opt => opt.Ignore())
                    .ForMember(a => a.UseAd, opt => opt.Ignore())
                    ;

                cfg.CreateMap<Article, V.Article.AritcleEditModel>()
                    .ForMember(a => a.Keywords, opt => opt.Ignore())
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    .ForMember(a => a.ContentOfAd, opt => opt.Ignore())
                    .ForMember(a => a.ChoosSeries, opt => opt.Ignore())
                    .ForMember(a => a.ChoosAd, opt => opt.Ignore())
                    .ForMember(a => a.Ad, opt => opt.Ignore())
                    .ForMember(a => a.WebSite, opt => opt.Ignore())
                    .ForMember(a => a.HasNewAd, opt => opt.Ignore())
                    .ForMember(a => a.Series, opt => opt.Ignore())
                    .ReverseMap()
                    .ForMember(a => a.Author, opt => opt.Ignore())
                    .ForMember(a => a.OwnKeyword, opt => opt.Ignore())
                    .ForMember(a => a.UseSeries, opt => opt.Ignore())
                    .ForMember(a => a.UseAd, opt => opt.Ignore())
                    ;

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

                UserRepository repository = new UserRepository(dbContext);
                User current = repository.Find(Convert.ToInt32(id));
                if (current.Password != pwd)
                {
                    throw new ArgumentException("你的信息有点点问题呀,我们攻城狮已经记录在册,并解决这个问题呦！");
                }
                return Convert.ToInt32(id);
            }
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


    }
}
