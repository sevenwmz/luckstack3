using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Repository
{
    public class BaceRepository<T>
    {
        public int GetSum(IList<T> name)
        {
            return name.Count;
        }
        public IList<T> Get(IList<T> name)
        {
            return name;
        }
        public void Add(T value, IList<T> name)
        {
            name.Add(value);
        }

    }
}
