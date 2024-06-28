using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre.Rules
{
    public class DiscountCannotBeNegativeRule : IBusinessRule
    {
        public decimal value { get; }
        public DiscountCannotBeNegativeRule(decimal value)
        {
            this.value = value;
        }

        public string Message => "Discount Cannot Be Negative";

        public bool IsBroken()
        {
            return value > 0;
        }
    }
}
