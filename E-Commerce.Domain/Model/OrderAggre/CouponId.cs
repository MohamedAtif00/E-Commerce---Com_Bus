using E_Commerce.Domain.Model.CouponAggre.Converters;
using E_Commerce.Domain.Model.OrderAggre.Converters;
using E_Commerce.SharedKernal.Domain;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Model.OrderAggre
{
    [EfCoreValueConverter(typeof(CouponConverter.CouponIdValueConverter))]
    [JsonConverter(typeof(CouponConverter.CouponIdJsonConverter))]
    [TypeConverter(typeof(CouponConverter.CouponIdTypeConverter))]
    public class CouponId : ValueObjectId, IValueObjectId<CouponId>
    {
        public CouponId(Guid id) : base(id)
        {
        }

        public static CouponId Create(Guid value)
        {
            return new(value);
        }

        public static CouponId CreateUnique()
        {
            return Create(Guid.NewGuid());
        }
    }
}