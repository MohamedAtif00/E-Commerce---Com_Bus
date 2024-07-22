using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.BasketAggre
{
    public class BasketId : ValueObjectId, IValueObjectId<BasketId>
    {
        public BasketId(Guid id) : base(id)
        {
        }

        public static BasketId Create(Guid value)
        {
            return new(value);
        }

        public static BasketId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}