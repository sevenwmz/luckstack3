﻿using EntityMVC;
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
    }
}
