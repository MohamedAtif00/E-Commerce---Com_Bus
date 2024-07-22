using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Identity.Domain.Model.UserRoleAggre
{
    public class UserRole : AggregateRoot<UserRoleId>
    {
        public UserRole(UserRoleId id) : base(id)
        {
        }
    }
}
