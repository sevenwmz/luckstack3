﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Keyword
    {
        public int Id { set; get; }

        public string Name { get; set; }
        public int Used { get; set; }

        public IList<Article> articles { set; get; }

        public IList<SecendKeyword> SecendKeyword { set; get; }

        public IList<Keyword> SelfDefined { set; get; }
    }
    public class SecendKeyword :Keyword
    {
    }
}
