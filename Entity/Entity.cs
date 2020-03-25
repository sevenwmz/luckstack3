using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Entity
    {

        #region Constructer
        public Entity(int number)
        {
            Id = number;
        }

        #endregion

        #region Filed and properties
        public int Id { get; }
        #endregion

    }
}
