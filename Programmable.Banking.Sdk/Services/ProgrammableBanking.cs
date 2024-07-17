using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Programmable.Banking.Sdk.Models;
using Programmable.Banking.Sdk.Models.Accounts;
using Programmable.Banking.Sdk.Models.Beneficiaries;
using Programmable.Banking.Sdk.Models.Cards;
using Programmable.Banking.Sdk.Models.Transactions;
using Programmable.Banking.Sdk.Options;
using System.Net.Http.Headers;
using System.Text;
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

        #region Card
        public async Task<Response<Results<Country>>> GetCountries()
        {
            await SetTokenAsync();

            var response = await _httpClient.GetAsync("za/v1/cards/countries");

            if (response.IsSuccessStatusCode)
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

        public async Task<Response<Results<Currency>>> GetCurrencies()
        {
            await SetTokenAsync();

            var response = await _httpClient.GetAsync("za/v1/cards/currencies");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var countries = JsonSerializer.Deserialize<Response<Results<Currency>>>(responseContent);

                return countries;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to get currencies: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }

        public async Task<Response<Results<Merchants>>> GetMerchants()
        {
            await SetTokenAsync();

            var response = await _httpClient.GetAsync("za/v1/cards/merchants");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var countries = JsonSerializer.Deserialize<Response<Results<Merchants>>>(responseContent);

                return countries;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to get merchants: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }
        #endregion

        #region Account
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

        public async Task<Response<Balance>> GetAccountBalance(string accountId)
        {
            await SetTokenAsync();

            var response = await _httpClient.GetAsync($"za/pb/v1/accounts/{accountId}/balance");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var balance = JsonSerializer.Deserialize<Response<Balance>>(responseContent);

                return balance;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to get account balance: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }

        public async Task<Response<TransactionList>> GetAccountTransactions(string accountId)
        {
            await SetTokenAsync();

            var response = await _httpClient.GetAsync($"za/pb/v1/accounts/{accountId}/transactions");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var transactions = JsonSerializer.Deserialize<Response<TransactionList>>(responseContent);

                return transactions;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to get account transactions: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }

        public async Task<Response<List<Transfer>>> TransferMultiple(string accountId, Transfers transferList)
        {
            await SetTokenAsync();

            var request = new HttpRequestMessage(HttpMethod.Post, $"za/pb/v1/accounts/{accountId}/transfermultiple")
            {
                Content = new StringContent(JsonSerializer.Serialize(transferList), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var transferResponse = JsonSerializer.Deserialize<Response<List<Transfer>>>(responseContent);

                return transferResponse;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to transfer: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }

        public async Task<Response<Account>> CreateAccount(Account account)
        {
            await SetTokenAsync();

            var request = new HttpRequestMessage(HttpMethod.Post, $"za/pb/v1/accounts")
            {
                Content = new StringContent(JsonSerializer.Serialize(account), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var accountResponse = JsonSerializer.Deserialize<Response<Account>>(responseContent);

                return accountResponse;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to create account: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }

        public async Task DeleteAccount(string accountId)
        {
            await SetTokenAsync();

            var response = await _httpClient.DeleteAsync($"za/pb/v1/accounts/{accountId}");

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to delete account: {StatusCode}: {Response}", response.StatusCode, responseContent);
            }
        }
        #endregion

        #region Beneficiary
        public async Task<Response<Beneficiary>> CreateBeneficiary()
        {
            await SetTokenAsync();

            var request = new HttpRequestMessage(HttpMethod.Post, $"za/pb/v1/accounts/beneficiaries")
            {
                Content = new StringContent("",Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var beneficiaryResponse = JsonSerializer.Deserialize<Response<Beneficiary>>(responseContent);

                return beneficiaryResponse;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to create beneficiary: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }

        public async Task<Response<Results<Beneficiary>>> GetBeneficiaries()
        {
            await SetTokenAsync();

            var response = await _httpClient.GetAsync($"za/pb/v1/accounts/beneficiaries");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var beneficiaries = JsonSerializer.Deserialize<Response<Results<Beneficiary>>>(responseContent);

                return beneficiaries;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to get beneficiaries: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }

        public async Task<Response<List<BeneficiaryPayment>>> BeneficiaryPayment(string accountId, BeneficiaryPayments payments)
        {
            await SetTokenAsync();

            var request = new HttpRequestMessage(HttpMethod.Post, $"za/pb/v1/accounts/{accountId}/paymultiple")
            {
                Content = new StringContent(JsonSerializer.Serialize(payments), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var beneficiaryPaymentResponse = JsonSerializer.Deserialize<Response<List<BeneficiaryPayment>>>(responseContent);

                return beneficiaryPaymentResponse;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to make beneficiary payment: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }
        #endregion

        #region Transaction
        public async Task<Response<Models.Transactions.Transaction>> CreateTransaction(string accountId, Models.Transactions.Transaction transaction)
        {
            await SetTokenAsync();

            var request = new HttpRequestMessage(HttpMethod.Post, $"za/pb/v1/accounts/{accountId}/transactions")
            {
                Content = new StringContent(JsonSerializer.Serialize(transaction), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var transactionResponse = JsonSerializer.Deserialize<Response<Models.Transactions.Transaction>>(responseContent);

                return transactionResponse;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to create transaction: {StatusCode}: {Response}", response.StatusCode, responseContent);
                return null;
            }
        }

        public async Task DeleteTransactions(string accountId, string postingDate)
        {
            await SetTokenAsync();

            var response = await _httpClient.DeleteAsync($"za/pb/v1/accounts/{accountId}/transactions/{postingDate}");

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Failed to delete account: {StatusCode}: {Response}", response.StatusCode, responseContent);
            }
        }
        #endregion

        private async Task SetTokenAsync()
        {
            string token = await _tokenService.GetTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}