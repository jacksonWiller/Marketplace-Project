using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface ICompra
    {
        Task addCompraAsync(Compra compra);

        //PRODUTOS
        Task<Compra[]> GetAllComprasAsync();
        Task<Compra[]> GetAllCompraAsyncByNome(string nome);
        Task<Compra> GetCompraAsyncById(int ComprasId);
    }
}