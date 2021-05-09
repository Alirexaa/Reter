using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Reter.Domain.UserAgg.Services
{
    public class HashPasswordService : IHashPasswordService
    {
        public CryptoPassword CreateHash(string password)
        {
            using var hmac = new HMACSHA256();

            return new CryptoPassword()
            {
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            };
        }

        public bool VerifyPasswordHash(string password,CryptoPassword cryptoPassword)
        {
            using var hmac =new HMACSHA256(cryptoPassword.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return !computeHash.Where((t, i) => cryptoPassword.PasswordHash[i] != t).Any();
        }
    }
}