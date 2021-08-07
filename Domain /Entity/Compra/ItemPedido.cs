using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class ItemPedido
    {
        [Column("ITEM_PEDIDO_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("ITEM_PEDIDO_PRECO")]
        [Display(Name = "Preço")]
        public int Preco { get; set; }

        [Column("ITEM_PEDIDO_QUANTIDADE")]
        [Display(Name = "Quantidade de Itens")]
        public int QtdItensPedidos { get; set; }

        [Column("ITEM_PEDIDO_OBSERVACAO")]
        [Display(Name = "Observação")]
        [MaxLength(20000)]
        public string Observacao { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int CompraId { get; set; }
        public virtual Compra Compra { get; set; }

    }
}