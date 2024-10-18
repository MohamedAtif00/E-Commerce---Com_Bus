using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.AdministrationAggre
{
    public class GroupId : ValueObjectId, IValueObjectId<GroupId>
    {
        public GroupId(Guid id) : base(id)
        {
        }

        public static GroupId Create(Guid value)
        {
            return new(value);
        }

        public static GroupId CreateUnique()
        {
            return Create(Guid.NewGuid());
        }
    }
}