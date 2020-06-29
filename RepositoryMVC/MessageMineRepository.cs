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





    }
}
