using E_Commerce.Domain.Model.OrderAggre;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.CouponAggre.Converters
{
    public class CouponConverter
    {
        public class CouponIdValueConverter : ValueConverter<CouponId, Guid>
        {
            public CouponIdValueConverter(ConverterMappingHints mappingHints = null)
               : base(id => id.value, value => CouponId.Create(value), mappingHints)
            {
            }
        }

        public class CouponIdJsonConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is CouponId id)
                {
                    serializer.Serialize(writer, id.value);
                }
                else
                {
                    writer.WriteNull();
                }
            }

            public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
            {
                var guid = serializer.Deserialize<Guid>(reader);
                return CouponId.Create(guid);
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(CouponId);
            }
        }

        public class CouponIdTypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
            {
                // Check if the source type is CouponId or if the base class can handle the conversion
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
            {
                // Attempt to convert from string to CouponId
                var stringValue = value as string;
                if (!string.IsNullOrEmpty(stringValue) && Guid.TryParse(stringValue, out var guid))
                {
                    return CouponId.Create(guid);
                }

                // Fallback to the base class conversion method
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
