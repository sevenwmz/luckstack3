using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class CommentsRepository : BaceRepository<Comments>
    {
        public CommentsRepository(SqlContext context) : base(context)
        {

        }

        public int SaveComment(Comments commentModel)
        {
            throw new NotImplementedException();
        }
    }
}
