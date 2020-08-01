using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RepositoryMVC
{
    public class CommentsRepository : BaceRepository<Comments>
    {
        public CommentsRepository(SqlContext context) : base(context)
        {

        }

        public int SaveComment(Comments comment)
        {
            entities.Add(comment);
            context.SaveChanges();
            return comment.Id;
        }

        public Comments GetSingleComment(int id)
        {
            return entities.Include(c => c.Author)
                        .Include(c => c.Reply)
                        .Include(c => c.Reply.Author)
                        .Where(c => c.Id == id)
                        .Single();
        }

        public IList<Comments> GetArticleComments(int id)
        {
            return entities.Include(c=>c.Author)
                        .Include(c=>c.Reply)
                        .Include(c => c.Reply.Author)
                        .OrderByDescending(c => c.Id)
                        .Where(c => c.BelongArticleId == id)
                        .ToList()
                        ;
        }

        public void DeleteCommentBy(Comments comments)
        {
            entities.Remove(comments);
        }
    }
}
