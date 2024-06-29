using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.OrderAggre
{
    public class OrderItemId : ValueObjectId, IValueObjectId<OrderItemId>
    {
        public OrderItemId(Guid id) : base(id)
        {
        }

        public static OrderItemId Create(Guid value)
        {
            return new(value);
        }

        public static OrderItemId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}