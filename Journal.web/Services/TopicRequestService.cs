using IdentityModel.Client;
using Journal.web.Extensions;
using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class TopicRequestService: ITopicRequestService
    {
        
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;
        

        public TopicRequestService(HttpClient client, TokenInjectionService tokenservice)
        {
            _client = client;
            _tokenInjectionService = tokenservice;
           
        }
        public async Task<IEnumerable<TopicDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/Topic/GetAll");
            return await response.ReadContentAs<List<TopicDto>>();
        }
        public async Task<TopicDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/Topic/GetTopicByID/{id}");
            return await response.ReadContentAs<TopicDto>();
        }
        //adds new paper
        public async Task Insert(TopicDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/Topic/AddTopic", obj);
        }
        public async Task Update(TopicDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"https://localhost:44225/api/Topic/UpdateTopic/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"https://localhost:44225/api/Topic/DeleteTopic/{id}");
        }
    }
}
