using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface IInstitutionRequestService
    {
        Task<IEnumerable<InstitutionDto>> Getall();
        Task<InstitutionDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(InstitutionDto obj);
        Task Update(InstitutionDto obj, object id);
        Task Delete(Guid id);
    }
}
