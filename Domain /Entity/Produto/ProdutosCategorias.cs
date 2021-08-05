using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class ProdutosCategorias
    {
        public Guid ProdutoId {get; set;}
        public virtual Produto Produto { get; set; }
        public int CategoriaId {get; set;}
        public virtual Categoria Categoria { get; set; }

    }
}