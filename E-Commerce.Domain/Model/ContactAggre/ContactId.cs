using E_Commerce.Domain.Model.CategoryAggre.Converters;
using E_Commerce.Domain.Model.ContactAggre.Converters;
using E_Commerce.SharedKernal.Domain;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Model.ContactAggre
{
    [EfCoreValueConverter(typeof(ContactConverter.ContactIdValueConverter))]
    [JsonConverter(typeof(ContactConverter.ContactIdJsonConverter))]
    [TypeConverter(typeof(ContactConverter.ContactIdTypeConverter))]
    public class ContactId : ValueObjectId, IValueObjectId<ContactId>
    {
        public ContactId(Guid id) : base(id)
        {
        }

        public static ContactId Create(Guid value)
        {
            return new(value);
        }

        public static ContactId CreateUnique()
        {
            return Create(Guid.NewGuid());
        }
    }
}