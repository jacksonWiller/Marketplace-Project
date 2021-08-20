using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class ProdutosCategorias
    {
        public Guid ProdutoId {get; set;}
        public Guid CategoriaId {get; set;}

    }
}