using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface ICategoryRequestService
    {
        Task<IEnumerable<CategoryDto>> Getall();
        Task<CategoryDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(CategoryDto obj);
        Task Update(CategoryDto obj, object id);
        Task Delete(Guid id);
    }
}
