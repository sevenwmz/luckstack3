using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RepositoryMVC
{
    public class ChatRepository : BaceRepository<Chat>
    {
        public ChatRepository(SqlContext content):base(content)
        {

        }

        /// <summary>
        /// Take chat message from db.
        /// </summary>
        /// <param name="count">Take chat message count</param>
        /// <returns>Return chat message list</returns>
        public IList<Chat> GetChatHistory(int count)
        {
            return entities.Include(c => c.ChatUser)
                        .Include(c => c.ChatWith)
                        .OrderByDescending(c => c.PublishTime)
                        .Skip(count)
                        .Take(20)
                        .ToList()
                        ;
        }
    }
}
