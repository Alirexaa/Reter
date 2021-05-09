using System;
using Public.Framework.Domain;
using Reter.Domain.UserAgg.Services;

namespace Reter.Domain.UserAgg
{
    public class User:DomainBase<string>
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public int Status  { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }




        
        protected  User()
        {
            
        }
        public User(string firstName, string lastName, string phone, string userName, string email, string password,IHashPasswordService hashPasswordService)
        {
            Id = Guid.NewGuid().ToString();
            Status = Statuses.New;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            UserName = userName;
            Email = email;
            var cryptoPassword = hashPasswordService.CreateHash(password);
            PasswordSalt = cryptoPassword.PasswordSalt;
            PasswordHash = cryptoPassword.PasswordHash;
        }

        public void Active()
        {
            Status = Statuses.Active;
        }

        public void DeActive()
        {
            Status = Statuses.DeActive;
        }

        public void Ben()
        {
           Status = Statuses.Ben;
        }
    }
}