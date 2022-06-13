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
    public class EditDecisionService : IEditDecisionService
    {
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;

        public EditDecisionService(HttpClient client, TokenInjectionService tokenInjectionService)
        {
            _client = client;
            _tokenInjectionService = tokenInjectionService;

        }
        public async Task<IEnumerable<EditDecisionsDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/EditDecisions/GetAll");
            return await response.ReadContentAs<List<EditDecisionsDto>>();
        }
        public async Task<EditDecisionsDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/EditDecisions/GetPaperByID/{id}");
            return await response.ReadContentAs<EditDecisionsDto>();
        }
        //adds new paper
        public async Task Insert(EditDecisionsDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/EditDecisions/SubmitPaper", obj);
        }
        public async Task Update(EditDecisionsDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"https://localhost:44225/api/EditDecisions/UpdatePaper/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"https://localhost:44225/api/EditDecisions/DeletePaper/{id}");
        }
    }
}
