using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface INotificationRequestService
    {
        Task<IEnumerable<NotificationDto>> GetAll();
        Task<NotificationDto> GetNotificationByID(object id);
        Task Insert(NotificationDto obj);
        Task Update(NotificationDto obj, object id);
        Task Delete(Guid id);
    }
}
