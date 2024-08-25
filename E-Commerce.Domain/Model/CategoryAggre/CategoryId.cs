
using E_Commerce.Domain.Model.CategoryAggre.Converters;
using E_Commerce.Domain.Model.ProductAggre.Converters;
using E_Commerce.SharedKernal.Domain;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Model.CategoryAggre
{
    [EfCoreValueConverter(typeof(CategoryConverter.CategoryIdValueConverter))]
    [JsonConverter(typeof(CategoryConverter.CategoryIdJsonConverter))]
    [TypeConverter(typeof(CategoryConverter.CategoryIdTypeConverter))]
    public class CategoryId : ValueObjectId, IValueObjectId<CategoryId>
    {
   
        public CategoryId(Guid id) : base(id)
        {
        }

        public static CategoryId Create(Guid value)
        {
            return new(value);
        }

        public static CategoryId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}