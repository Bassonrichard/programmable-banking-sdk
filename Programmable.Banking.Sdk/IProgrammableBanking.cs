using Programmable.Banking.Sdk.Models;
using Programmable.Banking.Sdk.Models.Accounts;
using Programmable.Banking.Sdk.Models.Cards;

namespace Programmable.Banking.Sdk
{
    public interface IProgrammableBanking
    {
        Task<Response<Results<Country>>> GetCountries();
        Task<Response<AccountList>> GetAccounts();
    }
}
