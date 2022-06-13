using IdentityModel.Client;
using Journal.web.Extensions;
using JournalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class ReviewerService : IReviewerService
    {
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;

        public ReviewerService(HttpClient client, TokenInjectionService tokenInjectionService)
        {
            _client = client;
            _tokenInjectionService = tokenInjectionService;

        }
        public async Task<IEnumerable<ReviewerDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("https://localhost:44225/api/Reviewer/GetAll");
            return await response.ReadContentAs<List<ReviewerDto>>();
        }
        public async Task<ReviewerDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"https://localhost:44225/api/Reviewer/GetReviewerByID/{id}");
            return await response.ReadContentAs<ReviewerDto>();
        }
        //adds new paper
        public async Task Insert(ReviewerDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("https://localhost:44225/api/Reviewer/SubmitReviewer", obj);
        }
        public async Task Update(ReviewerDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"https://localhost:44225/api/Reviewer/UpdateReviewer/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"https://localhost:44225/api/Reviewer/DeleteReviwer/{id}");
        }

    }
}
