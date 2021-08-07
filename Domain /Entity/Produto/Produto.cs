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
        [Key]
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }        
        public string Descricao { get; protected set; }
        public string Observacao { get; protected set; }
        public decimal Valor { get; protected set; }
        public int QuantidadeEmEstoque { get; protected set; }
        public bool Estado { get; protected set; }
        public DateTime DataDeCriacao { get; protected set; }
        public DateTime DataDeAlteracao { get; protected set; }
        public virtual ICollection<ProdutosCategorias> ProdutosCategorias { get; protected set; }

        public static Produto Create(string nome, string descricao, string observacao, decimal valor, 
                                        int quantidadeEmEstoque,  
                                        ICollection<ProdutosCategorias> produtosCategorias)
        {
            return Create(Guid.NewGuid(), nome, descricao, observacao, valor, quantidadeEmEstoque, produtosCategorias);
        }
        public static Produto Create(Guid id, string nome, string descricao, string observacao, 
                                        decimal valor, int quantidadeEmEstoque, 
                                        ICollection<ProdutosCategorias> produtosCategorias)
        {
            Produto produto = new Produto()
            {
                Nome = nome,
                Descricao = descricao,
                Observacao = observacao,
                Valor = valor,
                QuantidadeEmEstoque = quantidadeEmEstoque,
                Estado = true,
                DataDeCriacao = DateTime.Now,
                DataDeAlteracao = DateTime.Now,
                ProdutosCategorias = produtosCategorias
            }; 

            return produto;         
        }
    }    
}

