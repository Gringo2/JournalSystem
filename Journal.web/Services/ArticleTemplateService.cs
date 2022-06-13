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
    public class ArticleTemplateService : IArticleTemplateService
    {
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;

        public ArticleTemplateService(HttpClient client, TokenInjectionService tokenInjectionService)
        {
            _client = client;
            _tokenInjectionService = tokenInjectionService;

        }
        public async Task<IEnumerable<ArticleTemplateDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/PaperStore/GetAll");
            return await response.ReadContentAs<List<ArticleTemplateDto>>();
        }
        public async Task<ArticleTemplateDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/PaperStore/GetPaperByID/{id}");
            return await response.ReadContentAs<ArticleTemplateDto>();
        }
        //adds new paper
        public async Task Insert(ArticleTemplateDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/PaperStore/SubmitPaper", obj);
        }
        public async Task Update(ArticleTemplateDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"https://localhost:44225/api/PaperStore/UpdatePaper/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"https://localhost:44225/api/PaperStore/DeletePaper/{id}");
        }
    }
}
