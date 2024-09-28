using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.ShipmentInformationAggre
{
    public class PickAddressId : ValueObjectId, IValueObjectId<PickAddressId>
    {
        public PickAddressId(Guid id) : base(id)
        {
        }

        public static PickAddressId Create(Guid value)
        {
            return new(value);
        }

        public static PickAddressId CreateUnique()
        {
            return Create(Guid.NewGuid());
        }
    }
}