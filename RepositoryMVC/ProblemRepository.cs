using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class ProblemRepository : BaceRepository<Problem>
    {
        public ProblemRepository(DbContext contenxt) : base(contenxt)
        {

        }

        public int Add(Problem problemEntity)
        {
            entities.Add(problemEntity);
            context.SaveChanges();
            return problemEntity.Id;
        }

        public Problem GetEditProblem(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEditProblem(Problem problemEntity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return entities.Count();
        }

        public IList<Problem> GetProblems(int pageSize,int pageIndex)
        {
            return entities
                .Include(p => p.OwnKeyword.Select(o=>o.Keyword))
                .OrderByDescending(p => p.PublishTime)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
