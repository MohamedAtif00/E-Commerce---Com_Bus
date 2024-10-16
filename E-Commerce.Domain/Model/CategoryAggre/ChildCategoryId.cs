using E_Commerce.Domain.Model.CategoryAggre.Converters;
using E_Commerce.SharedKernal.Domain;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Model.CategoryAggre
{
    [EfCoreValueConverter(typeof(ChildCategoryConverter.ChildCategoryIdValueConverter))]
    [JsonConverter(typeof(ChildCategoryConverter.ChildCategoryIdJsonConverter))]
    [TypeConverter(typeof(ChildCategoryConverter.ChildCategoryIdTypeConverter))]
    public class ChildCategoryId : ValueObjectId, IValueObjectId<ChildCategoryId>
    {
        public ChildCategoryId(Guid id) : base(id)
        {
        }

        public static ChildCategoryId Create(Guid value)
        {
            return new(value);
        }

        public static ChildCategoryId CreateUnique()
        {
            return Create(Guid.NewGuid());
        }
    }
}