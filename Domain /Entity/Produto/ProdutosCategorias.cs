namespace Domain.Entity
{
    public class ProdutosCategorias
    {
        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; }

        public Produto Produto { get; set; }
        public Categoria Categoria { get; set; }  
    }
}