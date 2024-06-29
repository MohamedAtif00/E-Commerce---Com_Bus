using E_Commerce.SharedKernal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;


namespace E_Commerce.Infrastructure.Domain
{
    public static class ModelBuilderExtensions
    {

        public static ModelBuilder AddStronglyTypedIdValueConverters<T>(
            this ModelBuilder modelBuilder)
        {
            var assembly = typeof(T).Assembly;

            foreach (var type in assembly.GetTypes())
            {
                // try and get the attribute
                var attribute = type
                    .GetCustomAttributes<EfCoreValueConverterAttribute>().FirstOrDefault();

                if (attribute is null)
                {
                    continue;
                }

                // the ValueConverter must have a parameterless constructor
                var converter = (ValueConverter)Activator.CreateInstance(attribute.ValueConverter);

                // register the value converter for all EF core properties that use the id
                modelBuilder.UseValueConverter(converter);
            }

            return modelBuilder;
        }

        public static ModelBuilder UseValueConverter(this ModelBuilder modelBuilder, Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter converter)
        {
            // the-stronglyu typed ID type
            var type = converter.ModelClrType;

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties().Where(x =>x.PropertyType == type);

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property(property.Name)
                        .HasConversion(converter);
                }
            }

            return modelBuilder;
        }
    }
}
