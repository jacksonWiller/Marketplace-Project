using Domain.Entity;

namespace AplicationApp.Dtos
{
    public class ItemPedidoDto
    {
        public int Id { get; set; }
        public int Preco { get; set; }
        public int QtdItensPedidos { get; set; }
        public string Observacao { get; set; }
        public int ProdutoId { get; set; }
    }
}