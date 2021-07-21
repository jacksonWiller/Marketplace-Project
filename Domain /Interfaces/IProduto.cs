using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IProduto
    {
        //PRODUTOS
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto[]> GetAllProdutosAsyncByNome( string nome);
        Task<Produto> GetProdutoAsyncById(int ProdutosId);
    }

    
}