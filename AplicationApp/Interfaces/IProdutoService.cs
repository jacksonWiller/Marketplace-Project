using System;
using System.Threading.Tasks;
using AplicationApp.Dtos;

namespace AplicationApp.Interfaces
{
    public interface IProdutoService
    {   
        Task<ProdutoDto> AddProduto(ProdutoDto model);
        Task<ProdutoDto> UpdateProduto(Guid produtoId, ProdutoDto model);
        Task<bool> DeleteProduto(Guid produtoId);
        Task<ProdutoDto[]> GetAllProdutosAsync();
        Task<ProdutoDto[]> GetAllProdutosAsyncByNome( string nome);
        Task<ProdutoDto> GetProdutoAsyncById(Guid produtosId);
    }
}