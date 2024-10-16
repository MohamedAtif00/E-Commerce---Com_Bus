using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.ProductAggre
{
    public class ReviewId : ValueObjectId, IValueObjectId<ReviewId>
    {
        public ReviewId(Guid id) : base(id)
        {
        }

        public static ReviewId Create(Guid value)
        {
            return new(value);
        }

        public static ReviewId CreateUnique()
        {
            return Create(Guid.NewGuid());
        }
    }
}