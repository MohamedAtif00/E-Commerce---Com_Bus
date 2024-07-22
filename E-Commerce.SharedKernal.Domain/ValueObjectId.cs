using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Domain
{
    public abstract class ValueObjectId : ValueObject,IId
    {
        public Guid value { get;  set; }

        protected ValueObjectId(Guid id)
        {
            value = id;
        }



        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return value;
        }
    }

    public interface IId
    { }
}
