using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Categoria
    {
        [Column("CATEGORIA_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("CATEGORIA_NOME")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("CATEGORIA_DESCRICAO")]
        [Display(Name = "Descrição")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        public IEnumerable<ProdutosCategorias> ProdutosCategorias { get; set; }

    }
}