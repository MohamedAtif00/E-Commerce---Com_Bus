using E_Commerce.Domain.Model.ReviewAggre.Rules;
using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ReviewAggre
{
    public class Rating : ValueObject
    {
        public readonly HashSet<double> ratings = new() {0,0.5,1,1.5,2,2.5,3,3.5,4,4.5,5 };
        public double Value { get; private set; }

        public Rating(double value)
        {
            CheckRule(new RatingShouldOneOfHashsetValuesRules(ratings,value));
            Value = value;
        }

        public static Rating Create(double value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
