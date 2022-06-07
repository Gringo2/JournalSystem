using IdentityModel.Client;
using Journal.web.Extensions;
using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class CommentRequestService : ICommentRequestService
    {
        
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;
        

        public CommentRequestService(HttpClient client, TokenInjectionService tokenservice)
        {
            _client = client;
            _tokenInjectionService = tokenservice;
            
        }
        public async Task<IEnumerable<CommentsDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/PaperStore/GetAll");
            return await response.ReadContentAs<List<CommentsDto>>();
        }
        public async Task<CommentsDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/PaperStore/GetPaperByID/{id}");
            return await response.ReadContentAs<CommentsDto>();
        }
        //adds new paper
        public async Task Insert(CommentsDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/PaperStore/SubmitPaper", obj);
        }
        public async Task Update(CommentsDto obj, object id)
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
