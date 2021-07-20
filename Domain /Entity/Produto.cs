using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entity
{
    public class Produto
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public int Quantidade {get; set;}

        public Task<List<Produto[]>> ListarProdutos()
        {
            throw new System.NotImplementedException();
        }
    }
}