using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Comment
    {
        public Comment(Article article)
        {
            this.article = article;
        }

        public Article article { set; get; }

        public Appraise appraise { set; get; }

    }
}
