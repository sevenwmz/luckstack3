using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ChildAction
{
    public class ChildCategorySeriesModel
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public string Summary { set; get; }

        public IList<ChildCategorySeriesModel> ChildSeries { set; get; }

        public IList<ChildCategoryInsideSeriesModel> BrotherItems { set; get; }

    }

    public class ChildCategoryInsideSeriesModel
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public string Summary { set; get; }

    }




}
