using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface ITopicRequestService
    {
        Task<IEnumerable<TopicDto>> Getall();
        Task<TopicDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(TopicDto obj);
        Task Update(TopicDto obj, object id);
        Task Delete(Guid id);
    }
}
