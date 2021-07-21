using System.Collections.Generic;
using Domain.Entity;

namespace AplicationApp.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<ProdutosCategorias> ProdutosCategorias { get; set; }
    }
}