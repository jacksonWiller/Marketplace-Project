using System.Threading.Tasks;
using AplicationApp.Dtos;

namespace AplicationApp.Interfaces
{
    public interface ICompraService
    {
        Task<CompraDto> AddCompra(CompraDto model);
        Task<CompraDto> UpdateCompra(int compraId, CompraDto model);
        Task<bool> DeleteCompra(int compraId);
        Task<CompraDto[]> GetAllComprasAsync();
        Task<CompraDto[]> GetAllComprasAsyncByNome( string nome);
        Task<CompraDto> GetCompraAsyncById(int produtosId);     
    }
}