using E_Commerce.Domain.Model.CategoryAggre;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.CategoryAggre.Converters
{
    public class ChildCategoryConverter 
    {
        public class ChildCategoryIdValueConverter : ValueConverter<ChildCategoryId, Guid>
        {
            public ChildCategoryIdValueConverter(ConverterMappingHints mappingHints = null)
               : base(id => id.value, value => ChildCategoryId.Create(value), mappingHints)
            {
            }
        }

        public class ChildCategoryIdJsonConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is ChildCategoryId id)
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
                return ChildCategoryId.Create(guid);
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(ChildCategoryId);
            }
        }

        public class ChildCategoryIdTypeConverter : TypeConverter
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
                    return ChildCategoryId.Create(guid);
                }



                // Fallback to the base class conversion method
                return base.ConvertFrom(context, culture, value);
            }
        }


    }
}
