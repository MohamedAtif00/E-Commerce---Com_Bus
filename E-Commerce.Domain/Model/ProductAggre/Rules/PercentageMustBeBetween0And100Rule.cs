using E_Commerce.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre.Rules
{
    public class PercentageMustBeBetween0And100Rule : IBusinessRule
    {
        public int Value { get; }
        public PercentageMustBeBetween0And100Rule(int value)
        {
            Value = value;
        }

        public string Message => "Percentage must be between 0 and 100";

        public bool IsBroken()
        {
            return Value > 0 || Value > 100;
        }
    }
}
