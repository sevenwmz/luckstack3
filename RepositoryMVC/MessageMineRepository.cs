using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class MessageMineRepository : BaceRepository<MessageMine>
    {
        public MessageMineRepository(DbContext context) : base(context)
        {

        }

        public IList<MessageMine> GetMessage(int pageSize, int pageIndex)
        {
            return entities.Include(u=>u.Owner)
                    .OrderByDescending(a => a.PublishTime)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public int MessageCount(int currentUserId)
        {
            return entities.Count();
        }

        public MessageMine GetFindMessage(int id)
        {
            return entities.Find(id);
        }

        public void RemoveMessage(MessageMine message)
        {
            entities.Remove(message);
        }

        public IList<MessageMine> HasNewMessage(int messageOwner)
        {
            return entities.Where(m => m.OwnerId == messageOwner).ToList();
        }
    }
}
