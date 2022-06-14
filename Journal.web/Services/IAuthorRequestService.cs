using JournalSystem.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface IAuthorRequestService
    {
        Task<IEnumerable<AuthorDto>> Getall();
        Task<AuthorDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(AuthorDto obj);
        Task Update(AuthorDto obj, object id);
        Task Delete(Guid id);
    }
}
