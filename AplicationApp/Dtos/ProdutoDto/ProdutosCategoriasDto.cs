using System;

namespace AplicationApp.Dtos
{
    public class ProdutosCategoriasDto
    {
        public Guid CategoriaId {get; set;}
        public virtual CategoriaDto Categoria { get; set; }

    }
}