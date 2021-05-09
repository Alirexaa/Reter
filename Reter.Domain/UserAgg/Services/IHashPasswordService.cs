namespace Reter.Domain.UserAgg.Services
{
    public interface IHashPasswordService
    {
        CryptoPassword CreateHash(string password);
        bool VerifyPasswordHash(string password,CryptoPassword cryptoPassword);
    }
}