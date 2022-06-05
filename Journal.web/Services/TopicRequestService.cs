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
        private readonly string _hostWebApiUrl;
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;
        private readonly string _url;

        public TopicRequestService(HttpClient client, TokenInjectionService tokenservice, string hostWebApiUri)
        {
            _client = client;
            _tokenInjectionService = tokenservice;
            _hostWebApiUrl = hostWebApiUri;
        }
        public async Task<IEnumerable<TopicDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("/GetAll");
            return await response.ReadContentAs<List<TopicDto>>();
        }
        public async Task<TopicDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"/GetTopicByID/{id}");
            return await response.ReadContentAs<TopicDto>();
        }
        //adds new paper
        public async Task Insert(TopicDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("/AddTopic", obj);
        }
        public async Task Update(TopicDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"/UpdateTopic/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"/DeleteTopic/{id}");
        }
    }
}
