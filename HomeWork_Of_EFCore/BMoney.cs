
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    public class BMoney : BaceEntity
    {
        public int LeftBMoney { set; get; }
        public int LeftBPoint { set; get; }
        public int FreezingMoney { set; get; }
        public string Detail { set; get; }
        public DateTime LatesTime { set; get; }
        public string OwnerName { set; get; }
        public User Owner { set; get; }
    }
}
