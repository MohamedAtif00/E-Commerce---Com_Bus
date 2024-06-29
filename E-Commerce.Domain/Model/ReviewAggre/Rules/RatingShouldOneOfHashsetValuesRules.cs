using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ReviewAggre.Rules
{
    public class RatingShouldOneOfHashsetValuesRules : IBusinessRule
    {
        public HashSet<double> doubles { get;private set; }
        public double value { get; private set; }
        public RatingShouldOneOfHashsetValuesRules(HashSet<double> doubles, double value)
        {
            this.doubles = doubles;
            this.value = value;
        }

        public string Message => $"Rating Value Should one of following: {string.Join(',',doubles)}";

        public bool IsBroken()
        {
            return doubles.Contains(value);
        }
    }
}
