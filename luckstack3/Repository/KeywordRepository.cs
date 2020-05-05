using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Repository
{
    public class KeywordRepository
    {
        private static IList<Keyword> _keywords;

        static KeywordRepository()
        {
            _keywords = new List<Keyword>
            {
                new Keyword
                {
                    Name = "编程开发语言",
                    Id = 1,
                    SecendKeyword = new List<SecendKeyword>
                    {
                        new SecendKeyword{Name = "C#",Id = 1 },
                        new SecendKeyword{Name = "Java",Id = 2},
                        new SecendKeyword{Name = "Javascript",Id = 3},
                        new SecendKeyword{Name = "Html",Id = 4 },
                        new SecendKeyword{Name = "SQL",Id = 5 },
                        new SecendKeyword{Name = "Python",Id = 6},
                        new SecendKeyword{Name = "CSS",Id = 7},
                        new SecendKeyword{Name = "PHP",Id = 8}
                    },
                    SelfDefined = new List<Keyword>{}
                },
                new Keyword
                {
                    Name = "工具软件",
                    Id = 2,
                    SecendKeyword = new List<SecendKeyword>
                    {
                        new SecendKeyword{Name = "VisualStudio",Id = 1 },
                        new SecendKeyword{Name = "eclipse",Id = 2},
                        new SecendKeyword{Name = "IDEA",Id = 3},
                        new SecendKeyword{Name = "Excel",Id = 4 },
                        new SecendKeyword{Name = "Word",Id = 5 },
                        new SecendKeyword{Name = "CAD",Id = 6},
                        new SecendKeyword{Name = "Photoshop",Id = 7},
                        new SecendKeyword{Name = "PowerPoint",Id = 8}
                    },
                    SelfDefined = new List<Keyword>{}
                },
                new Keyword
                {
                    Name = "顾问咨询",
                    Id = 3,
                    SecendKeyword = new List<SecendKeyword>
                    {
                        new SecendKeyword{Name = "职场",Id = 1 },
                        new SecendKeyword{Name = "法律",Id = 2},
                        new SecendKeyword{Name = "财务",Id = 3},
                        new SecendKeyword{Name = "心理",Id = 4 },
                        new SecendKeyword{Name = "亲子",Id = 5 },
                        new SecendKeyword{Name = "婚姻家庭",Id = 6}
                    },
                    SelfDefined = new List<Keyword>{}
                },
                new Keyword
                {
                    Name = "操作系统",
                    Id = 4,
                    SecendKeyword = new List<SecendKeyword>
                    {
                        new SecendKeyword{Name = "Linux",Id = 1 },
                        new SecendKeyword{Name = "Windows",Id = 2},
                        new SecendKeyword{Name = "Android",Id = 3},
                        new SecendKeyword{Name = "Unix",Id = 4 },
                    },
                    SelfDefined = new List<Keyword>{}
                }
            };
        }

        public IList<Keyword> Get()
        {
            IList<Keyword> _orderKeywords = new List<Keyword>();
            foreach (var FristKeywords in _keywords)
            {
                _orderKeywords.Add(FristKeywords);
                foreach (var SecendKeywords in FristKeywords.SecendKeyword)
                {
                    _orderKeywords.Add(SecendKeywords);
                }
            }
            return _orderKeywords;
        }

        public IList<Keyword> GetKeywords()
        {
            return _keywords.ToList();
        }

    }


}
