using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface IEditDecisionService
    {
        Task<IEnumerable<EditDecisionsDto>> Getall();
        Task<EditDecisionsDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(EditDecisionsDto obj);
        Task Update(EditDecisionsDto obj, object id);
        Task Delete(Guid id);
    }
}
