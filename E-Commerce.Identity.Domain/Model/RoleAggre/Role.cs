using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Identity.Domain.Model.RoleAggre
{
    public class Role : AggregateRoot<RoleId>
    {
        public Role(RoleId id, string roleName) : base(id)
        {
            _roleName = roleName;
        }

        public string _roleName { get;private set; }

        public static Role Create(string roleName)
        {
            return new(RoleId.CreateUnique(),roleName);
        }

        public void Update(string roleName)
        {
            _roleName += roleName;
        }
    }
}
