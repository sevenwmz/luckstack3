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
