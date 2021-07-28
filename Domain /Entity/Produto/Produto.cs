using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Domain.Entity.Notifications;
using Domain.Interfaces;

namespace Domain.Entity
{
    [Table("Produtos")]
    public class Produto : Notifies
    {
        [Column("PRODUTO_ID")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("PRODUTO_NOME")]
        [Display(Name = "Nome")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Column("PRODUTO_DESCRICAO")]
        [Display(Name = "Descrição")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [Column("PRODUTO_OBSERVACAO")]
        [Display(Name = "Observação")]
        [MaxLength(20000)]
        public string Observacao { get; set; }

        [Column("PRODUTO_VALO")]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Column("PRODUTO_EM_ESTOQUE")]
        [Display(Name = "Quantidade Estoque")]
        public int QtdEstoque { get; set; }

        [Column("PRODUTO_ESTADO")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Column("PRODUTO_DATA_CADASTRO")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("PRODUTO_DATA_ALTERACAO")]
        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }

        public ICollection<ProdutosCategorias> ProdutosCategorias { get; set; }

    }    
}

