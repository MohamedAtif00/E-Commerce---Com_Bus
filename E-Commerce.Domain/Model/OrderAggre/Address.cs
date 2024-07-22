using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.OrderAggre
{
    public class Address : ValueObject
    {
        public Address(string state, string city, string street)
        {
            this.state = state;
            this.city = city;
            this.street = street;
        }

        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }

        public static Address Create(string state, string city, string street)
        {
            return new(state,city,street);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return this;
        }
    }
}
