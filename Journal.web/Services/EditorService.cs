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
    public class EditorService : IEditorService
    {
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;

        public EditorService(HttpClient client, TokenInjectionService tokenInjectionService)
        {
            _client = client;
            _tokenInjectionService = tokenInjectionService;

        }
        public async Task<IEnumerable<EditorDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/Editor/GetAll");
            return await response.ReadContentAs<List<EditorDto>>();
        }
        public async Task<EditorDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/Editor/GetEditorByID/{id}");
            return await response.ReadContentAs<EditorDto>();
        }
        //adds new paper
        public async Task Insert(EditorDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/Editor/SubmitEditor", obj);
        }
        public async Task Update(EditorDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"https://localhost:44225/api/Editor/Editor/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"https://localhost:44225/api/Editor/DeleteEditor/{id}");
        }
    }
}
