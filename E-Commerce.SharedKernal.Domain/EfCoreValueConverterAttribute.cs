using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Domain
{
    public class EfCoreValueConverterAttribute : Attribute
    {
        public Type ValueConverter { get; }
        public EfCoreValueConverterAttribute(Type valueConverter)
        {
            ValueConverter = valueConverter;
        }
    }
}
