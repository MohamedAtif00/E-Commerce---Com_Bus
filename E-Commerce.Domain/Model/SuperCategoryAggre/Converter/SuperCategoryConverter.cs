using E_Commerce.Domain.Model.CategoryAggre;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.SuperCategoryAggre.Converter
{
    public class SuperCategoryConverter
    {
        public class SuperCategoryIdValueConverter : ValueConverter<SuperCategoryId, Guid>
        {
            public SuperCategoryIdValueConverter(ConverterMappingHints mappingHints = null)
               : base(id => id.value, value => SuperCategoryId.Create(value), mappingHints)
            {
            }
        }
    }
}
