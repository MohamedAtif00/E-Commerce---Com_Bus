using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Identity.Domain.Model.UserAggre
{
    public class RoleId : ValueObjectId, IValueObjectId<RoleId>
    {
        public RoleId(Guid id) : base(id)
        {
        }

        public static RoleId Create(Guid value)
        {
            return new(value);
        }

        public static RoleId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}