namespace Programmable.Banking.Sdk.Options
{
    public class ProgrammableBankingOptions
    {
        public const string SectionName = "ProgrammableBanking";

        public required string BaseUrl { get; set; }
        public required string TokenEndpoint { get; set; }

        public required string ClientId { get; set; }
        public required string ClientSecret { get; set; }
        public required string ApiKey { get; set; }
    }
}
