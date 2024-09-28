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

namespace E_Commerce.Domain.Model.ContactAggre.Converters
{
    public class ContactConverter
    {
        public class ContactIdValueConverter : ValueConverter<ContactId, Guid>
        {
            public ContactIdValueConverter(ConverterMappingHints mappingHints = null)
               : base(id => id.value, value => ContactId.Create(value), mappingHints)
            {
            }
        }

        public class ContactIdJsonConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is ContactId id)
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
                return ContactId.Create(guid);
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(ContactId);
            }
        }

        public class ContactIdTypeConverter : TypeConverter
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
                    return ContactId.Create(guid);
                }



                // Fallback to the base class conversion method
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
