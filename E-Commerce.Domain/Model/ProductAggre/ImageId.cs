using E_Commerce.Domain.Model.ProductAggre.Converters;
using E_Commerce.SharedKernal.Domain;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace E_Commerce.Domain.Model.ProductAggre
{
    [EfCoreValueConverter(typeof(ImageConverter.ImageIdValueConverter))]
    [JsonConverter(typeof(ImageConverter.ImageIdJsonConverter))]
    [TypeConverter(typeof(ImageConverter.ImageIdTypeConverter))]
    public class ImageId : ValueObjectId, IValueObjectId<ImageId>
    {
        public ImageId(Guid id) : base(id)
        {
        }

        public static ImageId Create(Guid value)
        {
            return new(value);
        }

        public static ImageId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}