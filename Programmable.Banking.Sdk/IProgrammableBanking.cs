using Programmable.Banking.Sdk.Models;
using Programmable.Banking.Sdk.Models.Accounts;
using Programmable.Banking.Sdk.Models.Beneficiaries;
using Programmable.Banking.Sdk.Models.Cards;
using Programmable.Banking.Sdk.Models.Transactions;

namespace Programmable.Banking.Sdk
{
    public interface IProgrammableBanking
    {
        Task<Response<Results<Country>>> GetCountries();
        Task<Response<Results<Currency>>> GetCurrencies();
        Task<Response<Results<Merchants>>> GetMerchants();

        Task<Response<AccountList>> GetAccounts();
        Task<Response<Balance>> GetAccountBalance(string accountId);
        Task<Response<TransactionList>> GetAccountTransactions(string accountId);
        Task<Response<List<Transfer>>> TransferMultiple(string accountId, Transfers transferList);
        Task<Response<Account>> CreateAccount(Account account);
        Task DeleteAccount(string accountId);

        Task<Response<Beneficiary>> CreateBeneficiary();
        Task<Response<Results<Beneficiary>>> GetBeneficiaries();
        Task<Response<List<BeneficiaryPayment>>> BeneficiaryPayment(string accountId, BeneficiaryPayments payments);

        Task<Response<Models.Transactions.Transaction>> CreateTransaction(string accountId, Models.Transactions.Transaction transaction);
        Task DeleteTransactions(string accountId, string postingDate);
    }
}
