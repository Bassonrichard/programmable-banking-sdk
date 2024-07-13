using Programmable.Banking.Sdk.Models.Auth;
using Programmable.Banking.Sdk.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Programmable.Banking.Sdk
{
    public class TokenService
    {
        private readonly HttpClient _httpClient;
        private readonly BankingSimOptions _options;

        public TokenService(HttpClient httpClient, BankingSimOptions options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<string> GetTokenAsync()
        {
            var clientId = _options.ClientId;
            var clientSecret = _options.ClientSecret;
            var tokenEndpoint = _options.TokenEndpoint;

            var basicAuthHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            var request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basicAuthHeaderValue);
            request.Headers.Add("x-api-key", _options.ApiKey);

            request.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<Auth>(responseContent);

            return tokenResponse.AccessToken;
        }
    }
}
