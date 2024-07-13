namespace Programmable.Banking.Sdk.Options
{
    public class BankingSimOptions
    {
        public const string SectionName = "BankingSim";

        public required string ClientId { get; set; }
        public required string ClientSecret { get; set; }
        public required string ApiKey { get; set; }
        public required string TokenEndpoint { get; set; }
    }
}
