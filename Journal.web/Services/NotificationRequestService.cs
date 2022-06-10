using IdentityModel.Client;
using Journal.web.Extensions;
using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class NotificationRequestService : INotificationRequestService
    {
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;
        public NotificationRequestService(HttpClient client, TokenInjectionService tokenInjectionService)
        {
            _client = client;
            _tokenInjectionService = tokenInjectionService;
        }

        public async Task<IEnumerable<NotificationDto>> GetAll()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/Notification/GetAll");
            return await response.ReadContentAs<List<NotificationDto>>();
        }

        public async Task<NotificationDto> GetNotificationByID(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/GetNotificationByID/{id}");
            return await response.ReadContentAs<NotificationDto>();
        }

        public async Task Insert(NotificationDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/SubmitNotification", obj);
        }

        public async Task Update(NotificationDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"https://localhost:44225/api/UpdateNotification/{id}", obj);
        }      
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"https://localhost:44225/api/DeleteNotification/{id}");
        }
    }
}
