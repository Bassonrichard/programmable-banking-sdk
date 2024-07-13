using Programmable.Banking.Sdk;
using Programmable.Banking.Sdk.Models.Cards;
using Programmable.Banking.Sdk.Models;
using Programmable.Banking.Sdk.Models.Accounts;

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
.Produces<Response<Results<Country>>>();

app.MapGet("/accounts", async (IProgrammableBanking programmableBanking) =>
{
    return await programmableBanking.GetAccounts();
})
.WithName("GetAccounts")
.WithOpenApi()
.Produces<Response<AccountList>>();

app.Run();