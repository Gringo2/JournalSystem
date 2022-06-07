using IdentityModel.Client;
using Journal.web.Extensions;
using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class PaperRequestService :  IPaperRequestService
    {
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;

        public PaperRequestService(HttpClient client, TokenInjectionService tokenInjectionService)
        {
            _client = client;
            _tokenInjectionService = tokenInjectionService;
            
        }
        public async Task<IEnumerable<PaperDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/PaperStore/GetAll");
            return await response.ReadContentAs<List<PaperDto>>();
        }
        public async Task<PaperDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"/GetPaperByID/{id}");
            return await response.ReadContentAs<PaperDto>();
        }
        //adds new paper
        public async Task Insert(PaperDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("/SubmitPaper", obj);
        }
        public async Task Update(PaperDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"/UpdatePaper/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"/DeletePaper/{id}");
        }

    }
}
