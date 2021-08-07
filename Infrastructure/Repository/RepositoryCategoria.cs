using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryCategoria : ICategoria
    {
        
        public readonly DataContext _dataContext;
        
        public RepositoryCategoria(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Categoria[]> GetAllCategoriasAsync()
        {
            IQueryable<Categoria> query = _dataContext.Categorias;
               
            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Categoria[]> GetAllCategoriasAsyncByNome(string nome)
        {
            IQueryable<Categoria> query = _dataContext.Categorias;
            
             query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();

        }

         public async Task<Categoria> GetCategoriasAsyncById(Guid CategoriaId)
        {
            IQueryable<Categoria> query = _dataContext.Categorias;

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == CategoriaId);

            return await query.FirstOrDefaultAsync();
        }

    }
}