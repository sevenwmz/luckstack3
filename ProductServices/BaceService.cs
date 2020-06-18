﻿using AutoMapper;
using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V = ViewModel;

namespace ProductServices
{ 
    public class BaceService 
    {
        private static MapperConfiguration mapper;
        static BaceService()
        {
            mapper = new MapperConfiguration(cfg=>
            {
                cfg.CreateMap<User, V.RegisterModel>()
                    .ForMember(r=>r.PasswordAgain,opt=>opt.Ignore())
                    .ForMember(r=>r.Captcha,opt=>opt.Ignore())
                    .ForMember(r=>r.CookieId,opt=>opt.Ignore())
                    .ForMember(r=>r.Inviter,opt=>opt.Ignore())
                    .ForMember(r=>r.InviterNumber,opt=>opt.MapFrom(r=>r.MyInviterNumber))
                    .ReverseMap()
                    .ForMember(r=>r.Inviter,opt=>opt.Ignore())
                    ;
                cfg.CreateMap<User, V.Log.OnModel>()
                    .ForMember(l => l.LogInName, opt => opt.MapFrom(l => l.UserName))
                    .ForMember(l=>l.Captcha,opt=>opt.Ignore())
                    .ForMember(l=>l.RemenberMe,opt=>opt.Ignore())
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
                    .ForMember(a=>a.Author,opt=>opt.Ignore())
                    ;
            });
#if DEBUG
            mapper.AssertConfigurationIsValid();
#endif
        }

        protected IMapper connectedMapper
        {
            get => mapper.CreateMapper();
        }


    }
}
