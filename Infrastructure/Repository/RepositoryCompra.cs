using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;

namespace Infrastructure.Repository
{
    public class RepositoryCompra : ICompra
    {
        public readonly DataContext _dataContext;

        public async Task addCompraAsync(Compra compra){
            await _dataContext.Compras.AddAsync(compra);
            foreach (var itensDeCompra in compra.ItensDeCompra)
            {
                await _dataContext.ItemPedido.AddAsync(itensDeCompra);
            } 
            
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Compra[]> GetAllComprasAsync()
        {
            IQueryable<Compra> query = _dataContext.Compras;

            return await query.ToArrayAsync();
        }
        public async Task<Compra[]> GetAllCompraAsyncByNome(string nome)
        {
            IQueryable<Compra> query = _dataContext.Compras;

            return await query.ToArrayAsync();

        }
        public async Task<Compra> GetCompraAsyncById(int ComprasId)
        {
            IQueryable<Compra> query = _dataContext.Compras;

            return await query.FirstOrDefaultAsync();
        }

    }
}