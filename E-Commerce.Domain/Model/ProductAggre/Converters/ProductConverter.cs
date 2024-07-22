using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Globalization;

namespace E_Commerce.Domain.Model.ProductAggre.Converters
{
    public class ProductConverter
    {
        public class ProductIdValueConverter : ValueConverter<ProductId, Guid>
        {
            public ProductIdValueConverter(ConverterMappingHints mappingHints = null)
               : base(id => id.value, value => ProductId.Create(value), mappingHints)
            {
            }
        }

        public class ProductIdJsonConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is ProductId id)
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
                return ProductId.Create(guid);
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(ProductId);
            }
        }

        public class ProductIdTypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
            {
                // Check if the source type is ProductId or if the base class can handle the conversion
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
            {
                // Attempt to convert from string to ProductId
                var stringValue = value as string;
                if (!string.IsNullOrEmpty(stringValue) && Guid.TryParse(stringValue, out var guid))
                {
                    return ProductId.Create(guid);
                }

                // Fallback to the base class conversion method
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
