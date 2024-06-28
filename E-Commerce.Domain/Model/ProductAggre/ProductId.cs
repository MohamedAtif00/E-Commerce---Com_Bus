using E_Commerce.Domain.Model.ProductAggre.Converters;
using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.ProductAggre
{
    [EfCoreValueConverterAttribute(typeof(ValueConverter.ProductIdValueConverter))]
    public  class ProductId : ValueObjectId,IValueObjectId<ProductId>
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