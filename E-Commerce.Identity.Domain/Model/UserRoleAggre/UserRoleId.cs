using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Identity.Domain.Model.UserRoleAggre
{
    public class UserRoleId : ValueObjectId, IValueObjectId<UserRoleId>
    {
        public UserRoleId(Guid id) : base(id)
        {
        }

        public static UserRoleId Create(Guid value)
        {
            return new(value);
        }

        public static UserRoleId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}