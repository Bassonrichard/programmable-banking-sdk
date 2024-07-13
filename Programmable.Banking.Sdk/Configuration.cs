using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Programmable.Banking.Sdk.Options;
using Programmable.Banking.Sdk.Services;

namespace Programmable.Banking.Sdk
{
    public static class Configuration
    {
        public static IServiceCollection AddProgrammableBanking(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProgrammableBankingOptions>(configuration.GetSection(ProgrammableBankingOptions.SectionName));
            var options = configuration.GetSection(ProgrammableBankingOptions.SectionName).Get<ProgrammableBankingOptions>();

            services.AddHttpClient<IProgrammableBanking, ProgrammableBanking>(pb =>
            {
                pb.BaseAddress = new Uri(options.BaseUrl);
            });

            services.AddHttpClient<ITokenService, TokenService>();

            return services;
        }
    }
}
