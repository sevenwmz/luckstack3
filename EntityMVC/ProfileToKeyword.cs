using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class ProfileToKeyword : BaceEntity
    {
        public int ProfileId { set; get; }
        public Profile Profile { set; get; }
        public int KeywordId { set; get; }
        public Keywords Keyword { set; get; }

    }
}
