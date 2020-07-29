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
        public ChatRepository(SqlContext content) : base(content)
        {

        }

        /// <summary>
        /// Take chat message from db.
        /// </summary>
        /// <param name="count">Take chat message count</param>
        /// <returns>Return chat message list</returns>
        public IList<Chat> GetChatHistory(int count)
        {
            return entities.Include(c => c.Author)
                        .Include(c => c.Reply)
                        .OrderBy(c => c.PublishTime)
                        .Skip(count)
                        .Take(20)
                        .ToList()
                        ;
        }

        /// <summary>
        /// Save chat to Db
        /// </summary>
        /// <param name="newChat">Need chat info</param>
        /// <returns>Return new chat id</returns>
        public int SaveChat(Chat newChat)
        {
            entities.Add(newChat);
            context.SaveChanges();
            return newChat.Id;
        }

        /// <summary>
        /// Get chat info
        /// </summary>
        /// <param name="id">Need chat id</param>
        /// <returns>Return chat obj</returns>
        public Chat GetChat(int id)
        {
            return entities.Include(c => c.Author)
                        .Include(c => c.Reply)
                        .Include(c=>c.Reply.Author)
                        .Where(c => c.Id == id)
                        .Single();
        }
    }
}
