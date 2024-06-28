

using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.SpecificationAggre
{
    public class SpecificationId : ValueObjectId, IValueObjectId<SpecificationId>
    {
        public SpecificationId(Guid id) : base(id)
        {
        }

        public static SpecificationId Create(Guid value)
        {
            return new(value);
        }

        public static SpecificationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}