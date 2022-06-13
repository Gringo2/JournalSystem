using JournalSystem.Entities;
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
        Task<IEnumerable<T>> GetByCategory(Guid categoryId);
        Task<IEnumerable<T>> GetByTopic(Guid topicId);
        Task<IEnumerable<T>> GetPaperUser(Guid paperId);
        Task<IEnumerable<T>> GetUserPaper(Guid userId);
        void AddUserPaper(Paper obj, User ob);
        void AddPaperUser(User obj, Paper ob);
        //Task<IEnumerable<T>> SortPapers(int n);
        Task Insert(T obj);
        Task Update(T obj);
        Task<T> Delete(Guid id);
        Task<T> LoadRelatedAsync();
    }
}
