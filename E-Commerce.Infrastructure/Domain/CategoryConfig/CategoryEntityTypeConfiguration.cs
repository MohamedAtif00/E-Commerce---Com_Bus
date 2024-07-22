using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.SuperCategoryAggre;
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
            builder.Property(x => x._parentCategoryId).HasConversion(x =>x.value,value=>CategoryId.Create(value));
            builder.Property(x => x.SuperCategoryId).HasConversion(x =>x.value,value=>SuperCategoryId.Create(value));
        }
    }
}
