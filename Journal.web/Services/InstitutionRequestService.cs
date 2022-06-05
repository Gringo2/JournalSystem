using IdentityModel.Client;
using Journal.web.Extensions;
using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class InstitutionRequestService: IInstitutionRequestService
    {
        private readonly string _hostWebApiUrl;
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;
        private readonly string _url;

        public InstitutionRequestService(HttpClient client, TokenInjectionService tokenservice, string hostWebApiUri)
        {
            _client = client;
            _tokenInjectionService = tokenservice;
            _hostWebApiUrl = hostWebApiUri;
        }
        public async Task<IEnumerable<InstitutionDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/PaperStore/GetAll");
            return await response.ReadContentAs<List<InstitutionDto>>();
        }
        public async Task<InstitutionDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/PaperStore/GetPaperByID/{id}");
            return await response.ReadContentAs<InstitutionDto>();
        }
        //adds new paper
        public async Task Insert(InstitutionDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/PaperStore/SubmitPaper", obj);
        }
        public async Task Update(InstitutionDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"https://localhost:44225/api/PaperStore/SubmitPaper/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"https://localhost:44225/api/PaperStore/DeleteProduct/{id}");
        }
    }
}
