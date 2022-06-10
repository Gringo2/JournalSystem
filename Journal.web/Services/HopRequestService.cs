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
    public class HopRequestService : IHopRequestService
    {
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;
        public HopRequestService(HttpClient client, TokenInjectionService tokenInjectionService)
        {
            _client = client;
            _tokenInjectionService = tokenInjectionService;
        }


        public async Task<IEnumerable<HopDto>> GetAll()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/Hop/GetAll");
            return await response.ReadContentAs<List<HopDto>>();
        }

        public async Task<HopDto> GetHopByID(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/GetHopByID/{id}");
            return await response.ReadContentAs<HopDto>();
        }

        public async Task Insert(HopDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/SubmitHop", obj);
        }

        public async Task Update(HopDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"https://localhost:44225/api/UpdateHop/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"https://localhost:44225/api/DeleteHop/{id}");
        }
    }
}
