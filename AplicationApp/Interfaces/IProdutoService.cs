using System.Threading.Tasks;
using AplicationApp.Dtos;

namespace AplicationApp.Interfaces
{
    public interface IProdutoService
    {   
        Task<ProdutoDto> AddProduto(ProdutoDto model);
        Task<ProdutoDto> UpdateProduto(int produtoId, ProdutoDto model);
        Task<bool> DeleteProduto(int produtoId);
        Task<ProdutoDto[]> GetAllProdutosAsync();
        Task<ProdutoDto[]> GetAllProdutosAsyncByNome( string nome);
        Task<ProdutoDto> GetProdutoAsyncById(int produtosId);
    }
}