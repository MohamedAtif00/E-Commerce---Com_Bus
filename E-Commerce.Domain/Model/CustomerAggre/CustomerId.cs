using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.CustomerAggre
{
    public class CustomerId : ValueObjectId, IValueObjectId<CustomerId>
    {
        public CustomerId(Guid id) : base(id)
        {
        }

        public static CustomerId Create(Guid value)
        {
            return new(value);
        }

        public static CustomerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}