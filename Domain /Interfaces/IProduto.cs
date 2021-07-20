using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IProduto
    {
        Task<List<Produto[]>> ListarProdutos();
    }

    
}