using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public class TokenInjectionService
    {
        private readonly HttpClient _client;
        private string _accessToken;

        public TokenInjectionService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetToken()
        {
            if (!string.IsNullOrWhiteSpace(_accessToken))
            {
                return _accessToken;
            }

            //get the discovery document from our authorization server which uses identity model
            var discoveryDocumentResponse = await _client.GetDiscoveryDocumentAsync("https://localhost:5001/");
            if (discoveryDocumentResponse.IsError)
            {
                throw new Exception(discoveryDocumentResponse.Error);
            }

            //send validation request to the token endpoint with a client Credetial Grant
            var tokenResponse = await _client.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocumentResponse.TokenEndpoint,
                    ClientId = "client",
                    ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
                    Scope = "scope1"
                });
            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }
            _accessToken = tokenResponse.AccessToken;
            return _accessToken;


        }
    }
}