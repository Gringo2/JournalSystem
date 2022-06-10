using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface IHopRequestService
    {
        Task<IEnumerable<HopDto>> GetAll();
        Task<HopDto> GetHopByID(object id);
        Task Insert(HopDto obj);
        Task Update(HopDto obj, object id);
        Task Delete(Guid id);
    }
}
