using JournalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface IReviewerService
    {
        Task<IEnumerable<ReviewerDto>> Getall();
        Task<ReviewerDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(ReviewerDto obj);
        Task Update(ReviewerDto obj, object id);
        Task Delete(Guid id);
    }
}
