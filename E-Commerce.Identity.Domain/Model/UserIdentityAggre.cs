using E_Commerce.Identity.Domain.Asbtraction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Identity.Domain.Model
{
    public class UserIdentityAggre : UserEntity
    {
        public UserIdentityAggre(UserId id) : base(id)
        {
           
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
