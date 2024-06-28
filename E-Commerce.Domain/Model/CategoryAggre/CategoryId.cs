
using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.CategoryAggre
{
    public class CategoryId : ValueObjectId, IValueObjectId<CategoryId>
    {
        public CategoryId(Guid id) : base(id)
        {
        }

        public static CategoryId Create(Guid value)
        {
            return new(value);
        }

        public static CategoryId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}