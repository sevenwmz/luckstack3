using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class ChildSeriesModel
    {
        public int AuthorId { set; get; }

        public string AuthorName { set; get; }

        public int Id { set; get; }

        public string Title { set; get; }

        public string Summary { set; get; }

        public IList<ChildSeriesModel> Items { set; get; }

    }
}