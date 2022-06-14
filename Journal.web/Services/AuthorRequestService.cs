using IdentityModel.Client;
using Journal.web.Extensions;
using JournalSystem.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class AuthorRequestService : IAuthorRequestService
    {
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;

        public AuthorRequestService(HttpClient client, TokenInjectionService tokenInjectionService)
        {
            _client = client;
            _tokenInjectionService = tokenInjectionService;

        }
        public async Task<IEnumerable<AuthorDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/Author/GetAll");
            return await response.ReadContentAs<List<AuthorDto>>();
        }
        public async Task<AuthorDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/Author/GetAuthorByID/{id}");
            return await response.ReadContentAs<AuthorDto>();
        }
        //adds new paper
        public async Task Insert(AuthorDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/Author/SubmitAuthor", obj);
        }
        public async Task Update(AuthorDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"https://localhost:44225/api/Author/UpdateAuthor/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"https://localhost:44225/api/Author/DeleteAuthor/{id}");
        }
    }
}
