namespace Programmable.Banking.Sdk
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync();
    }
}
