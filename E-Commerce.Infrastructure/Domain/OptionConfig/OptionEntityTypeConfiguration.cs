using E_Commerce.Domain.Model.SpecificationAggre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Domain.OptionConfig
{
    public class OptionEntityTypeConfiguration : IEntityTypeConfiguration<Options>
    {
        public void Configure(EntityTypeBuilder<Options> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x =>x.Id).HasConversion(x => x.value,x=>OptionsId.Create(x));

            builder.Property(x => x.specificationId).HasConversion(x =>x.value,x =>SpecificationId.Create(x));
        }
    }
}
