using Infrastructure.Repository.Gererics;
using Domain.Entity;
using Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProAgil.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryProduto : RepositoryGeneric, IRepositoryProduto
    {
        public readonly DataContext _dataContext;

        public RepositoryProduto(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _dataContext.Produtos;
               
            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Produto[]> GetAllProdutosAsyncByNome(string nome)
        {
            IQueryable<Produto> query = _dataContext.Produtos;
            
             query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();

        }

         public async Task<Produto> GetProdutoAsyncById(int ProdutoId)
        {
            IQueryable<Produto> query = _dataContext.Produtos;

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == ProdutoId);

            return await query.FirstOrDefaultAsync();
        }

        
    }
}