using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Identity.Domain.Model.UserAggre
{
    public class Role 
    {
        public static Role User => new Role(nameof(User));
        public static Role Admin => new Role(nameof(Admin));

        public string value { get;private set; }
        public Role(string value) 
        {
            this.value = value;
        }
        


    }
}
