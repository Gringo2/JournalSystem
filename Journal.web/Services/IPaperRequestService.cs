using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface IPaperRequestService
    {
        Task<IEnumerable<PaperDto>> Getall();
        Task<PaperDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(PaperDto obj);
        Task Update(PaperDto obj, object id);
        Task Delete(Guid id);
    }
}
