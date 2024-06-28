
using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.SpecificationAggre
{
    public class OptionsId : ValueObjectId, IValueObjectId<OptionsId>
    {
        public OptionsId(Guid id) : base(id)
        {
        }

        public static OptionsId Create(Guid value)
        {
            return new(value);
        }

        public static OptionsId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}