﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI
{
    public class Const
    {
        //For Page
        public const string PAGE_INDEX = "pageIndex";
        public const int PAGE_SIZE = 2;

        //For Cookie
        public const string COOKIE_USER = "user";
        public const string COOKIE_NAME = "SevenMarkLogIn";

        //用户标记已读
        public const string NOTICE_HASREAD = "NoticeHasRead";

        //用户上一次读取时间
        public const string NOTICE_LATEST_READ = "NoticeLatestRead";

        //FOR Url
        public const string PREPAGE = "prepage";
        public const string PRE_REGISTER = "preRegister";
        public const string ROLE = "role";
        public const string PRE_PAGE_INDEX = "path";
        public const string SIZE = "size";
        public const string SORT = "sort";

        //For Session
        public const string SESSION_USER = "user";
        public const string SESSION_VALUE = "SevenMark";
        public const string SESSION_CAPTCHA = "Captcha";

        //For Article User url
        public const string USER = "User-";

        //For ViewData
        public const string SERIES_ARTICLE = "SeriesArticle";
    }
}