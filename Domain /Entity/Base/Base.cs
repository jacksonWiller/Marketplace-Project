using System;

namespace Domain.Entity
{
    public abstract class Base
    {
       public bool Estado { get; protected set; }
        public DateTime DataDeCriacao { get; protected set; }
        public DateTime DataDeAlteracao { get; protected set; } 
    }
}