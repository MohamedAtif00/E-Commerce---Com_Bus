using E_Commerce.SharedKernal.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Identity.Domain.Model.UserAggre
{
    public sealed class User :IdentityUser<Guid>
    {
        public User(string email, string firstName, string lastName) 
        {
            Email = email;
            _firstName = firstName;
            _lastName = lastName;
        }

        public string _firstName { get; private set; }
        public string _lastName { get; private set; }

        public static User Create( string email,string firstName, string lastName)
        {
            return new(email,firstName,lastName);
        }

        public void Update( string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

    }
}
