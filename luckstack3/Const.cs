using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang
{
    public class Const
    {
        //For Page
        public const string PAGE_INDEX = "pageIndex";
        public const int PAGE_SIZE = 10;

        //For Cookie
        public const string COOKIE_USER = "user";
        public const string COOKIE_VALUE = "SevenMark";

        /// <summary>
        /// 用户标记已读
        /// </summary>
        public const string NOTICE_HASREAD = "NoticeHasRead";
        /// <summary>
        /// 用户上一次读取时间
        /// </summary>
        public const string NOTICE_LATEST_READ = "NoticeLatestRead";


        //FOR Url
        public const string PREPAGE = "prepage";
        public const string ROLE = "role";
        public const string PRE_PAGE_INDEX = "path";

        //For Session
        public const string SESSION_USER = "user";
        public const string SESSION_VALUE = "SevenMark";

        //For UserID
        public const string USER_ID = "userId";

        //For ViewData
        public const string SERIES_ARTICLE = "SeriesArticle";
    }
}
