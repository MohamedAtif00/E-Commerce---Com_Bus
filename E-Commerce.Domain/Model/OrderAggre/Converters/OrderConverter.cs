using E_Commerce.Domain.Model.ProductAggre;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.OrderAggre.Converters
{
    public class OrderConverter
    {
        public class OrderIdValueConverter : ValueConverter<OrderId, Guid>
        {
            public OrderIdValueConverter(ConverterMappingHints mappingHints = null)
               : base(id => id.value, value => OrderId.Create(value), mappingHints)
            {
            }
        }

        public class OrderIdJsonConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is OrderId id)
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
                return OrderId.Create(guid);
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(OrderId);
            }
        }

        public class OrderIdTypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
            {
                // Check if the source type is OrderId or if the base class can handle the conversion
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
            {
                // Attempt to convert from string to OrderId
                var stringValue = value as string;
                if (!string.IsNullOrEmpty(stringValue) && Guid.TryParse(stringValue, out var guid))
                {
                    return OrderId.Create(guid);
                }

                // Fallback to the base class conversion method
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
