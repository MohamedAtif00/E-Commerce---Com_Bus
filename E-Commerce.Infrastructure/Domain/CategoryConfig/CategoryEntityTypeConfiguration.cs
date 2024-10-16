using E_Commerce.Domain.Model.CategoryAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace E_Commerce.Infrastructure.Domain.CategoryConfig
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,value =>CategoryId.Create(value));


            builder.HasMany(x => x.ChildCategories).WithOne(x => x.category).HasForeignKey("_parentCategoryId").OnDelete(DeleteBehavior.NoAction);

            //builder.OwnsMany(x => x.ChildCategories, conf =>
            //{
            //    conf.HasKey(x => x.Id);
            //    conf.Property(x => x.Id).HasConversion(x => x.value, value => ChildCategoryId.Create(value));

            //    conf.Property(x => x._parentCategoryId).HasConversion(x => x.value, value => CategoryId.Create(value));

            //    conf.Property(x => x._parentChildCategoryId).HasConversion(x => x.value, value => ChildCategoryId.Create(value));

            //    //conf.OwnsMany(x => x.ChildCategories);
            //});
        }
    }
}
