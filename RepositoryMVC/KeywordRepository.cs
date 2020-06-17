using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class KeywordRepository
    {
        private SqlContext _context;

        public IList<int> AddKeywordToDatabase(IList<Keywords> keywords)
        {
            IList<int> tempKeywordId = new List<int>();
            foreach (var item in keywords)
            {
                _context.Keywords.Add(item);
                tempKeywordId.Add(item.Id);
            }
            _context.SaveChanges();
            return tempKeywordId;
        }
    }
}
