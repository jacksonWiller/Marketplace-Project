using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class ProdutosCategorias
    {
        public int ProdutoId {get; set;}
        public int CategoriaId {get; set;}

    }
}