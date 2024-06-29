using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Identity.Domain.Model.UserAggre
{
    public sealed class User : AggregateRoot<UserId>
    {
        public User(UserId id, string username, string password, string email, string firstName, string lastName) : base(id)
        {
            _username = username;
            _password = password;
            _email = email;
            _firstName = firstName;
            _lastName = lastName;
        }

        public string _username { get;private set; }
        public string _password { get; private set; }
        public string _email { get; private set; }
        public string _firstName { get; private set; }
        public string _lastName { get; private set; }

        public List<Role> roles { get; private set; }
        public static User Create(string username, string password, string email, string firstName, string lastName)
        {
            return new(UserId.CreateUnique(),username,password,email,firstName,lastName);
        }

        public void Update(string username, string password, string email, string firstName, string lastName)
        {
            _username  = username;
            _password = password;
            _email = email;
            _firstName = firstName;
            _lastName = lastName;
        }

    }
}
