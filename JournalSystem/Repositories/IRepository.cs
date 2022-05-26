using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JournalSystem.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(T obj);
        Task Update(T obj);
        Task<T> Delete(Guid id);
        Task<T> LoadRelatedAsync();
    }
}
