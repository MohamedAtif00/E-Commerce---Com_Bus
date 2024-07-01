using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.CategoryAggre.Converters;
using E_Commerce.Domain.Model.SuperCategoryAggre.Converter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace E_Commerce.Infrastructure.Domain.CategoryConfig
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(new CategoryConverter.CategoryIdValueConverter());
            builder.Property(x => x._parentCategoryId).HasConversion(new CategoryConverter.CategoryIdValueConverter());
            builder.Property(x => x.SuperCategoryId).HasConversion(new SuperCategoryConverter.SuperCategoryIdValueConverter());
        }
    }
}
