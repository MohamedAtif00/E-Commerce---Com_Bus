using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.Domain.Model.ProductAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.SpecialProductsConfig
{
    public class SpecialProductsEntityTypeConfiguration : IEntityTypeConfiguration<SpecialProducts>
    {
        public void Configure(EntityTypeBuilder<SpecialProducts> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.value,value => SpecialProductsId.Create(value));
            builder.Property(x => x.productId).HasConversion(x => x.value, value => ProductId.Create(value));
        }
    }
}
