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
        //adds new paper
        public async Task AddPaper(PaperDto obj)
        {
            await _client.PostAsJson("https://localhost:44225/api/PaperStore/SubmitPaper", obj);
        }

        public async Task DeletePaper(Guid id)
        {
            await _client.DeleteAsync("https://localhost:44225/api/PaperStore/DeleteProduct/{id}");
        }

        public async Task<IEnumerable<PaperDto>> GetallPapers()
        {
            var response = await _client.GetAsync("https://localhost:44225/api/PaperStore/GetAll");
            return await response.ReadContentAs<List<PaperDto>>();
        }

        public async Task<PaperDto> GetById(object id)
        {
            var response = await _client.GetAsync($"https://localhost:44225/api/PaperStore/GetPaperByID/{id}");
            return await response.ReadContentAs<PaperDto>();
        }

        public async Task UpdatePaper(PaperDto obj)
        {
            var pid = obj.PaperId;
            var response = await _client.PostAsJson("https://localhost:44225/api/PaperStore/SubmitPaper/{pid}", obj);
        }
    }
}
