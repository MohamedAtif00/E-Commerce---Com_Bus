using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.ShipmentAggre
{
    public class ShipmentId : ValueObjectId, IValueObjectId<ShipmentId>
    {
        public ShipmentId(Guid id) : base(id)
        {
        }

        public static ShipmentId Create(Guid value)
        {
            return new(value);
        }

        public static ShipmentId CreateUnique()
        {
            return Create(Guid.NewGuid());
        }
    }
}