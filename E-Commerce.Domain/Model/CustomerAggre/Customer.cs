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
        public Customer(CustomerId id) : base(id)
        {
        }

        public string _name { get;private set; }
        public string email { get;private set; }

    }
}
