using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.CustomerAggre
{
    public class Customer : AggregateRoot<CustomerId>
    {
        public Customer(CustomerId id, string name, string email) : base(id)
        {
            _name = name;
            this.email = email;
        }

        public string _name { get;private set; }
        public string email { get;private set; }

        public static Customer Create(string name,string email)
        {
            return new(CustomerId.CreateUnique(),name,email);
        }
    }
}
