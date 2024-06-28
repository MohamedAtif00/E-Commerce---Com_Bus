using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Identity.Domain.Model
{
    public class UserId : ValueObjectId ,IValueObjectId<UserId>,IEquatable<UserId>
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

        public bool Equals(UserId? other)
        {
            if (other is null)
                return false;

            return value.Equals(other.value);
        }
    }
}