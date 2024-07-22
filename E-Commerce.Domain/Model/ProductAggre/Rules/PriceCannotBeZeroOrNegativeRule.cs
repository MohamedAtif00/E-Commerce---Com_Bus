using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre.Rules
{
    public class PriceCannotBeZeroOrNegativeRule : IBusinessRule
    {
        public decimal Value { get;}
        public PriceCannotBeZeroOrNegativeRule(decimal value)
        {
            Value = value;
        }

        public string Message => "Price Cannot be Zero or Negative";

        public bool IsBroken()
        {
            return Value <= 0; 
        }
    }
}
