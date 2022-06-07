using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface ICommentRequestService
    {
        Task<IEnumerable<CommentsDto>>  Getall();
        Task<CommentsDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(CommentsDto obj);
        Task Update(CommentsDto obj, object id);
        Task Delete(Guid id);
    }
}
