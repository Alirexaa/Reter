namespace Reter.Domain.UserAgg
{
    public class CryptoPassword
    {
        public byte[] PasswordHash { get;  set; }
        public byte[] PasswordSalt { get;  set; }

    }
}