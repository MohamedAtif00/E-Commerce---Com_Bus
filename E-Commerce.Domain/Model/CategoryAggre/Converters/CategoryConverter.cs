using E_Commerce.Domain.Model.ProductAggre;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.CategoryAggre.Converters
{
    public class CategoryConverter
    {
        public class CategoryIdValueConverter : ValueConverter<CategoryId, Guid>
        {
            public CategoryIdValueConverter(ConverterMappingHints mappingHints = null)
               : base(id => id.value, value => CategoryId.Create(value), mappingHints)
            {
            }
        }
    }
}
