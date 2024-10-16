using E_Commerce.Domain.Model.CategoryAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.CategoryConfig
{
    public class ChildCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ChildCategory>
    {
        public void Configure(EntityTypeBuilder<ChildCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value, value => ChildCategoryId.Create(value));

            builder.Property(x => x._parentCategoryId).HasConversion(x => x.value, value => CategoryId.Create(value));
            builder.HasOne(c => c.category) // Changed from category to ParentCategory
           .WithMany(c => c.ChildCategories)
           .HasForeignKey("_parentCategoryId")
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.childCategory).WithMany(x => x.ChildCategories).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.ChildCategories)
           .WithOne(c => c.childCategory) // Changed from childCategory to ParentChildCategory
           .HasForeignKey("_parentChildCategoryId")
           .OnDelete(DeleteBehavior.NoAction); // Choose the delete behavior that suits your needs

           builder.Property(x => x._parentChildCategoryId).HasConversion(x => x.value, value => ChildCategoryId.Create(value));
        }



        
    }
}
