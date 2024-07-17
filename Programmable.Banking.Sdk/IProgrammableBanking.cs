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
        Task<Response<Balance>> GetAccountBalance(string accountNumber);
        Task<Response<TransactionList>> GetAccountTransactions(string accountNumber);
        Task<Response<List<Transfer>>> TransferMultiple(string accountNumber, Transfers transferList);
        Task<Response<Account>> CreateAccount(Account account);
        Task DeleteAccount(string accountNumber);

        Task<Response<Beneficiary>> CreateBeneficiary();
        Task<Response<Results<Beneficiary>>> GetBeneficiaries();
        Task<Response<List<BeneficiaryPayment>>> BeneficiaryPayment(string accountNumber, BeneficiaryPayments payments);

        Task<Response<Models.Transactions.Transaction>> CreateTransaction(string accountNumber, Models.Transactions.Transaction transaction);
        Task DeleteTransactions(string accountNumber, string postingDate);
    }
}
