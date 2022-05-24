using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface IPaperStoreService
    {
        Task<IEnumerable<PaperDto>> GetallPapers();
        Task<PaperDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task AddPaper(PaperDto obj);
        Task UpdatePaper(PaperDto obj);
        Task DeletePaper(Guid id);

    }
}
