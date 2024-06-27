using E_Commerce.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre.Rules
{
    public class StockQuantityCannotBeNegativeRule : IBusinessRule
    {
        public int value { get; }

        public StockQuantityCannotBeNegativeRule(int value)
        {
            this.value = value;
        }

        public string Message => "There is not enough Inventory";

        public bool IsBroken()
        {
            return value < 0;
        }
    }
}
