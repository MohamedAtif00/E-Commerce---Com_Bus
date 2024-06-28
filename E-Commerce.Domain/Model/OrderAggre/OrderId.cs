using E_Commerce.Domain.Abstraction;

namespace E_Commerce.Domain.Model.OrderAggre
{
    public class OrderId : ValueObjectId, IValueObjectId<OrderId>
    {
        public OrderId(Guid id) : base(id)
        {
        }

        public static OrderId Create(Guid value)
        {
            return new(value);
        }

        public static OrderId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}