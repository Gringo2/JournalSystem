using IdentityModel.Client;
using Journal.web.Extensions;
using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class CategoryRequestService : ICategoryRequestService
    {
       
        private readonly HttpClient _client;
        private readonly TokenInjectionService _tokenInjectionService;
        

        public CategoryRequestService(HttpClient client, TokenInjectionService tokenservice)
        {
            _client = client;
            _tokenInjectionService = tokenservice;
            
        }
        public async Task<IEnumerable<CategoryDto>> Getall()
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync("/GetAll");
            return await response.ReadContentAs<List<CategoryDto>>();
        }
        public async Task<CategoryDto> GetById(object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.GetAsync($"/GetCategoryByID/{id}");
            return await response.ReadContentAs<CategoryDto>();
        }
        //adds new paper
        public async Task Insert(CategoryDto obj)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.PostAsJson("/AddCategory", obj);
        }
        public async Task Update(CategoryDto obj, object id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            var response = await _client.PostAsJson($"/UpdateCategory/{id}", obj);
        }
        public async Task Delete(Guid id)
        {
            _client.SetBearerToken(_tokenInjectionService.GetToken().ToString());
            await _client.DeleteAsync($"/DeleteCategory/{id}");
        }
    }
}
