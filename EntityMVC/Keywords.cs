using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Keywords : BaceEntity
    {
        public string Name { set; get; }
        public int Used { set; get; }

        public int? LevelId { set; get; }
        public Keywords Level { set; get; }
        #region Obsoletion
        public int? NormalLevelId { set; get; }
        public Keywords NormalLevel { set; get; }
        public int? SecendLevelId { set; get; }
        public Keywords SecendLevel { set; get; }
        public int? FristLevelId { set; get; }
        public Keywords FirstLevel { set; get; }
        #endregion


        public IList<KeywordsAndArticle> UseArticle { set; get; }

        public IList<Keywords> GetKeywordList(string keywords)
        {
            IList<Keywords> tempKeywordList = new List<Keywords>();
            if (!string.IsNullOrEmpty(keywords))
            {
                string[] temp = keywords.Trim().Split(' ');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(temp[i]))
                    {
                        tempKeywordList.Add(new Keywords { Name = temp[i] });
                    }
                }
            }
            return tempKeywordList;
        }

        public Keywords AddUsed(Keywords item)
        {
            item.Used = ++item.Used;
            return item;
        }

        public Keywords AddNewKeyword(Keywords keyword)
        {
            return new Keywords
            {
                Name = keyword.Name,
                Used = ++keyword.Used
            };
        }
    }
}
