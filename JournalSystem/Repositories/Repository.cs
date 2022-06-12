using JournalSystem.Context;
using JournalSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JournalSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataDbContext _context;
        private readonly DbSet<T> table = null;
        public Repository(DataDbContext context) { 
            _context = context;
            table = _context.Set<T>();
            
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await table.FindAsync(id);
        }
        public async Task<T> GetPaperUser(Guid PaperId)
        {
            var paper = _context.Papers
                .Include(p => p.Users)
                .ThenInclude(u => u.RoleId).ToList()

            var user = _context.Users
                .Include(u => u.Papers)
                .ThenInclude(t => t.PaperId).ToList();
        }
        public async Task<IEnumerable<T>> GetByCategory(Guid categoryId)
        {
            var x = await _context.Topics.Where(d => d.CategoryId == categoryId).ToListAsync();
            return (IEnumerable<T>) x;
        }

        public async Task<IEnumerable<T>> GetByTopic(Guid topicId)
        {
            var x = await _context.Papers.Where(d => d.TopicId == topicId).ToListAsync();
            return (IEnumerable<T>)x;
        }

        public async Task Insert(T obj)
        {
            await table.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
             table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<T> Delete(Guid id)
        {
            T existing = await table.FindAsync(id);
            if (existing == null)
            {
                return existing;
            }
            
            else
            {
                table.Remove(existing);
                await _context.SaveChangesAsync();
                return existing;
            }
            
        }
        public Task<T> LoadRelatedAsync()
        {
            throw new NotImplementedException();
        }

        //public async Task<T> GetByCategory(object categoryId)
        //{
        //    return T;
        //}
    }
}
