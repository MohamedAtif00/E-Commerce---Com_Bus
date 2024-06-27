using E_Commerce.Domain.Abstraction;

namespace E_Commerce.Domain.Model.ProductAggre
{
    public class BrandId : ValueObjectId,IValueObjectId<BrandId>
    {
        public BrandId(Guid id) : base(id)
        {
        }

        public static BrandId Create(Guid value)
        {
            return new BrandId(value);
        }

        public static BrandId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}