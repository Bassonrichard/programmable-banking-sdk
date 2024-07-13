using Microsoft.Extensions.Options;
using Programmable.Banking.Sdk.Models.Auth;
using Programmable.Banking.Sdk.Options;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Programmable.Banking.Sdk.Services
{
    public class TokenService: ITokenService
    {
        private readonly HttpClient _httpClient;
        private readonly ProgrammableBankingOptions _options;

        public TokenService(HttpClient httpClient, IOptions<ProgrammableBankingOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<string> GetTokenAsync()
        {
            var clientId = _options.ClientId;
            var clientSecret = _options.ClientSecret;

            var basicAuthHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            var url = _options.BaseUrl + _options.TokenEndpoint;
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url, UriKind.Absolute),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                })
            };
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
