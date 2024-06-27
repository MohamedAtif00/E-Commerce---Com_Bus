using E_Commerce.Domain.Abstraction;

namespace E_Commerce.Domain.Model.ProductAggre
{
    public class ProductId : ValueObjectId,IValueObjectId<ProductId>
    {
        protected ProductId(Guid id) : base(id)
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