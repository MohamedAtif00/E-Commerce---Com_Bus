using E_Commerce.Domain.Model.ProductAggre.Converters;
using E_Commerce.Domain.Model.ProductOptionAggre;
using E_Commerce.Domain.Model.SpecificationAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.ProductOptionConfig
{
    public class ProductOptionEntityTypeConfiguration : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x =>x.value,x =>ProductOptionId.Create(x));

            builder.Property(x => x._productId).HasConversion(new ProductConverter.ProductIdValueConverter());

            builder.Property(x => x._optionsId).HasConversion(x =>x.value,x =>OptionsId.Create(x));

        }
    }
}
