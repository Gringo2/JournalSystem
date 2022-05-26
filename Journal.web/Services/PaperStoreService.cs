using IdentityModel.Client;
using Journal.web.Extensions;
using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class PaperStoreService : IPaperStoreService
    {
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;

        public PaperStoreService(HttpClient client, TokenInjectionService tokenservice)
        {
            _client = client;
            _tokenInjectionService = tokenservice;
        }
        public async Task<IEnumerable<PaperDto>> GetallPapers()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/PaperStore/GetAll");
            return await response.ReadContentAs<List<PaperDto>>();
        }
        public async Task<PaperDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/PaperStore/GetPaperByID/{id}");
            return await response.ReadContentAs<PaperDto>();
        }
        //adds new paper
        public async Task AddPaper(PaperDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/PaperStore/SubmitPaper", obj);
        }
        public async Task UpdatePaper(PaperDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var pid = obj.PaperId;
            var response = await _client.PostAsJson($"https://localhost:44225/api/PaperStore/SubmitPaper/{pid}", obj);
        }
        public async Task DeletePaper(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"https://localhost:44225/api/PaperStore/DeleteProduct/{id}");
        }
    }
}
