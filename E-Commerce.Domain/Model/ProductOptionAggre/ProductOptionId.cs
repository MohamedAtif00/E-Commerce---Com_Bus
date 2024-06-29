

using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.ProductOptionAggre
{
    public class ProductOptionId : ValueObjectId, IValueObjectId<ProductOptionId>
    {
        public ProductOptionId(Guid id) : base(id)
        {
        }

        public static ProductOptionId Create(Guid value)
        {
            return new(value);
        }

        public static ProductOptionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}