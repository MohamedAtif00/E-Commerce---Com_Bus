using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.AdministrationAggre
{
    public class SpecialProductsId : ValueObjectId, IValueObjectId<SpecialProductsId>
    {
        public SpecialProductsId(Guid id) : base(id)
        {
        }

        public static SpecialProductsId Create(Guid value)
        {
            return new(value);
        }

        public static SpecialProductsId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}