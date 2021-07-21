using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Categoria
    {
        [Column("PRD_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("PRD_NOME")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        public IEnumerable<ProdutosCategorias> ProdutosCategorias { get; set; }

    }
}