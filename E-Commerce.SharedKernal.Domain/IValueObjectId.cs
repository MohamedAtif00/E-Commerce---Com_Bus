using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Domain
{
    public interface IValueObjectId<T>
    {
        static abstract T Create(Guid value);
        static abstract T CreateUnique();
    }
}
