

using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.SuperCategoryAggre
{
    public class SuperCategoryId : ValueObjectId, IValueObjectId<SuperCategoryId>
    {
        public SuperCategoryId(Guid id) : base(id)
        {
        }

        public static SuperCategoryId Create(Guid value)
        {
            return new(value);
        }

        public static SuperCategoryId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}