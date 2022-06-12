using Journal.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class StatusRequestService : IStatusRequestService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenInjectionService _tokenInjectionService;
        public StatusRequestService(HttpClient httpClient, TokenInjectionService tokenInjectionService)
        {
            _httpClient = httpClient;
            _tokenInjectionService = tokenInjectionService;

        }

        public Task<IEnumerable<TopicDto>> Getall()
        {
            throw new System.NotImplementedException();
        }
    }
}
