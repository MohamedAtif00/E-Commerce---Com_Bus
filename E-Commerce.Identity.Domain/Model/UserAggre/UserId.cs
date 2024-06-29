using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Identity.Domain.Model.UserAggre
{
    public class UserId : ValueObjectId, IValueObjectId<UserId>
    {
        public UserId(Guid id) : base(id)
        {
        }

        public static UserId Create(Guid value)
        {
            return new(value);
        }

        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}