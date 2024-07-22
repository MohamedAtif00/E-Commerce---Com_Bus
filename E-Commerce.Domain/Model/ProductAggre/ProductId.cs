using E_Commerce.Domain.Model.ProductAggre.Converters;
using E_Commerce.SharedKernal.Domain;
using Newtonsoft.Json;
using System.ComponentModel;



namespace E_Commerce.Domain.Model.ProductAggre
{
    [EfCoreValueConverter(typeof(ProductConverter.ProductIdValueConverter))]
    [JsonConverter(typeof(ProductConverter.ProductIdJsonConverter))]
    [TypeConverter(typeof(ProductConverter.ProductIdTypeConverter))]
    public sealed class ProductId : ValueObjectId,IValueObjectId<ProductId>
    {
        public ProductId(Guid id) : base(id)
        {
        }

        public static ProductId Create(Guid id)
        {
            return new ProductId(id);
        }


        public static ProductId CreateUnique()
        {
            return new(Guid.NewGuid());
        }



    }


}