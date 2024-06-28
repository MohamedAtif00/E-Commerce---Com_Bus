using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Domain
{
    public abstract class ValueObjectId : ValueObject
    {
        public Guid value { get; private set; }

        protected ValueObjectId(Guid id)
        {
            value = id;
        }



        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return value;
        }
    }
}
