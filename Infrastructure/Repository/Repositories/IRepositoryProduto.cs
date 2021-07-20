using System.Threading.Tasks;
using Domain.Entity;

namespace Infrastructure.Repository.Interfaces
{
    public interface IRepositoryProduto : IRepositoryGeneric
    {
        
        //PRODUTOS
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto[]> GetAllProdutosAsyncByNome( string nome);
        Task<Produto> GetProdutoAsyncById(int ProdutosId);
     
    }
}