using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;

namespace Infrastructure.Repository.Gererics
{
    public class RepositoryGeneric : IRepositoryGeneric
    {
        private readonly DataContext _dataContext;
        public RepositoryGeneric (DataContext dataContext)
        {
            _dataContext = dataContext;
            // _dataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }
         public void Update<T>(T entity) where T : class
        {
            _dataContext.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }
        // public void DeleteRange<T>(T[] entityArray) where T : class
        // {
        //      _dataContext.RemoveRange(entityArray);
        // }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _dataContext.SaveChangesAsync()) > 0;
        }
    }
}