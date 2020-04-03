using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Entity<T> 
    {
        private T Id { get; }

        public Entity(T number)
        {
            Id = number;
        }

    }
}
