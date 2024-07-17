using Programmable.Banking.Sdk;
using Programmable.Banking.Sdk.Models.Cards;
using Programmable.Banking.Sdk.Models;
using Programmable.Banking.Sdk.Models.Accounts;
using Programmable.Banking.Sdk.Models.Transactions;
using Microsoft.AspNetCore.Mvc;
using Programmable.Banking.Sdk.Models.Beneficiaries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Setup Programmable Banking SDK
builder.Services.AddProgrammableBanking(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/countries", async (IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.GetCountries();
})
.WithName("GetCountries")
.WithOpenApi()
.Produces<Response<Results<Currency>>>();

app.MapGet("/currencies", async (IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.GetCurrencies();
})
.WithName("GetCurrencies")
.WithOpenApi()
.Produces<Response<Results<Currency>>>();

app.MapGet("/merchants", async (IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.GetMerchants();
})
.WithName("GetMerchants")
.WithOpenApi()
.Produces<Response<Results<Merchants>>>();

app.MapGet("/accounts", async (IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.GetAccounts();
})
.WithName("GetAccounts")
.WithOpenApi()
.Produces<Response<AccountList>>();

app.MapGet("/accounts/{accountId}/balance", async (string accountId, IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.GetAccountBalance(accountId);
})
.WithName("GetAccountBalance")
.WithOpenApi()
.Produces<Response<Balance>>();

app.MapGet("/accounts/{accountId}/transactions", async (string accountId, IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.GetAccountTransactions(accountId);
})
.WithName("GetAccountTransactions")
.WithOpenApi()
.Produces<Response<TransactionList>>();

app.MapPost("/accounts/{accountId}/transfer/multiple", async (string accountId, Transfers transfers, IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.TransferMultiple(accountId, transfers);
})
.WithName("TransferMultiple")
.WithOpenApi()
.Produces<Response<List<Transfer>>>();

app.MapPost("/accounts/create", async (Account account, IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.CreateAccount(account);
})
.WithName("CreateAccount")
.WithOpenApi()
.Produces<Response<Account>>();

app.MapDelete("/accounts/{accountId}/delete", async (string accountId, IProgrammableBanking programmableBanking) =>
{
    await programmableBanking.DeleteAccount(accountId);
})
.WithName("DeleteAccount")
.WithOpenApi();

app.MapPost("/beneficiaries/create", async (IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.CreateBeneficiary();
})
.WithName("CreateBeneficiary")
.WithOpenApi()
.Produces<Response<Beneficiary>>();

app.MapGet("/beneficiaries", async (IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.GetBeneficiaries();
})
.WithName("GetBeneficiaries")
.WithOpenApi()
.Produces<Response<Results<Beneficiary>>>();

app.MapPost("/beneficiaries/{accountId}/payment", async (string accountId, BeneficiaryPayments beneficiaryPayments, IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.BeneficiaryPayment(accountId, beneficiaryPayments);
})
.WithName("BeneficiaryPayment")
.WithOpenApi()
.Produces<Response<List<BeneficiaryPayment>>>();

app.MapPost("/accounts/{accountId}/transactions", async (string accountId, Programmable.Banking.Sdk.Models.Transactions.Transaction beneficiaryPayments, IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.CreateTransaction(accountId, beneficiaryPayments);
})
.WithName("CreateTransaction")
.WithOpenApi()
.Produces<Response<Programmable.Banking.Sdk.Models.Transactions.Transaction>>();

app.MapDelete("/accounts/{accountId}/transactions/delete", async (string accountId, string postingDate, IProgrammableBanking programmableBanking) =>
{
    await programmableBanking.DeleteTransactions(accountId, postingDate);
})
.WithName("DeleteTransactions")
.WithOpenApi();

app.Run();