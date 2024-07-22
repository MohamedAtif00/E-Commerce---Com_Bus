using E_Commerce.SharedKernal.Domain;

namespace E_Commerce.Domain.Model.ProductAggre
{
    public class ImageId : ValueObjectId, IValueObjectId<ImageId>
    {
        public ImageId(Guid id) : base(id)
        {
        }

        public static ImageId Create(Guid value)
        {
            return new(value);
        }

        public static ImageId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
    }
}