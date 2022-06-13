using Journal.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface IStatusRequestService 
    {

        Task<IEnumerable<TopicDto>> Getall();
    }
}
