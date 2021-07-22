using System;
using System.Collections.Generic;
using Domain.Entity;

namespace AplicationApp.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public int QtdEstoque { get; set; }
        public bool Estado { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        
        public ICollection<Categoria> Categorias { get; set; }
    }
}