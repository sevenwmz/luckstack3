using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC.Extension
{
    public static class BMoneyExtension
    {
        public static void AddNewRow(this BMoneyRepository bMoney , BMoney InsertInfo)
        {
            SqlContext _repository = new SqlContext();
            _repository.BMoneys.Add(InsertInfo);
            _repository.SaveChanges();
        }
    }
}
