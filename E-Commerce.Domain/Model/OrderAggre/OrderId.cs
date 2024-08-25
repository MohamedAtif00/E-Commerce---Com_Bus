using E_Commerce.Domain.Model.OrderAggre.Converters;
using E_Commerce.Domain.Model.ProductAggre.Converters;
using E_Commerce.SharedKernal.Domain;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Model.OrderAggre
{
    [EfCoreValueConverter(typeof(OrderConverter.OrderIdValueConverter))]
    [JsonConverter(typeof(OrderConverter.OrderIdJsonConverter))]
    [TypeConverter(typeof(OrderConverter.OrderIdTypeConverter))]
    public class OrderId : ValueObjectId, IValueObjectId<OrderId>
    {
        public OrderId(Guid id) : base(id)
        {
        }

        public static OrderId Create(Guid value)
        
        {
            return new(value);
        }

        public static OrderId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}