using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Programmable.Banking.Sdk.Models;
using Programmable.Banking.Sdk.Models.Accounts;
using Programmable.Banking.Sdk.Models.Cards;
using Programmable.Banking.Sdk.Options;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Programmable.Banking.Sdk.Services
{
    public class ProgrammableBanking : IProgrammableBanking
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;
        private readonly ILogger<ProgrammableBanking> _logger;
        private readonly ProgrammableBankingOptions _options;

        public ProgrammableBanking(HttpClient httpClient,
                                   ITokenService tokenService,
                                   ILogger<ProgrammableBanking> logger,
                                   IOptions<ProgrammableBankingOptions> options)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<Response<Results<Country>>> GetCountries()
        {
            await SetTokenAsync();

            var response = await _httpClient.GetAsync("za/v1/cards/countries");

            if(response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var countries = JsonSerializer.Deserialize<Response<Results<Country>>>(responseContent);

                return countries;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to get countries: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }

        public async Task<Response<AccountList>> GetAccounts()
        {
            await SetTokenAsync();

            var response = await _httpClient.GetAsync("za/pb/v1/accounts");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var accounts = JsonSerializer.Deserialize<Response<AccountList>>(responseContent);

                return accounts;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to get accounts: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }

        private async Task SetTokenAsync()
        {
            string token = await _tokenService.GetTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
