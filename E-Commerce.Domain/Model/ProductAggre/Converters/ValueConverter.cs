using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.ProductAggre.Converters
{
    internal class ValueConverter
    {
        public class ProductIdValueConverter : ValueConverter<ProductId, Guid>
        {
            public ProductIdValueConverter(ConverterMappingHints mappingHints = null)
               : base(id => id.value, value => ProductId.Create(value), mappingHints)
            {
            }
        }

 
    }
}
