using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.ShipmentInformationAggre
{
    public class ShipmentInformationId : ValueObjectId, IValueObjectId<ShipmentInformationId>
    {
        public ShipmentInformationId(Guid id) : base(id)
        {
        }

        public static ShipmentInformationId Create(Guid value)
        {
            return new(value);
        }

        public static ShipmentInformationId CreateUnique()
        {
            return Create(Guid.NewGuid());
        }
    }
}