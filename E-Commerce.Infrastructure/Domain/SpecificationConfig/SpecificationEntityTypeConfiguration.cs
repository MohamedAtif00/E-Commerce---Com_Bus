using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.SpecificationAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.SpecificationConfig
{
    public class SpecificationEntityTypeConfiguration : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x=>x.value,x =>SpecificationId.Create(x));
            builder.Property(x => x.CategoryId).HasConversion(x =>x.value,x =>CategoryId.Create(x));

        }
    }
}
