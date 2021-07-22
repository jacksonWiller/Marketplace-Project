using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;

namespace Infrastructure.Repository.Gererics
{
    public class RepositoryGeneric<T>  : IGeneric<T> where T : class
    {
        private readonly DataContext _dataContext;
        public RepositoryGeneric (DataContext dataContext)
        {
            _dataContext = dataContext;
            // _dataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task Add(T Objeto)
        {
            await _dataContext.Set<T>().AddAsync(Objeto);
            await _dataContext.SaveChangesAsync();
        }
        public async Task Update(T Objeto)
        {
             _dataContext.Set<T>().Update(Objeto);
            await _dataContext.SaveChangesAsync();
        }
        public async Task Delete(T Objeto)
        {
            _dataContext.Set<T>().Remove(Objeto);
            await _dataContext.SaveChangesAsync();
        }
        public async Task<T> GetEntityById(int Id)
        {
            return await _dataContext.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> List()
        {
            return await _dataContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dataContext.SaveChangesAsync()) > 0;
        }

        
    }
}