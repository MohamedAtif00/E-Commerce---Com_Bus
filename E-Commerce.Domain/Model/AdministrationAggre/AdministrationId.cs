using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.AdministrationAggre
{
    public class AdministrationId : ValueObjectId, IValueObjectId<AdministrationId>
    {
        public AdministrationId(Guid id) : base(id)
        {
        }

        public static AdministrationId Create(Guid value)
        {
            return new(value);
        }

        public static AdministrationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}