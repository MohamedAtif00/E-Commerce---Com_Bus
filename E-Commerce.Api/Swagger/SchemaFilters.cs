using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ContactAggre;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace E_Commerce.Api.Swagger
{
    public class SchemaFilters 
    {
        public class CompositeSchemaFilter : ISchemaFilter
        {
            private readonly IEnumerable<ISchemaFilter> _schemaFilters;

            public CompositeSchemaFilter(IEnumerable<ISchemaFilter> schemaFilters)
            {
                _schemaFilters = schemaFilters;
            }

            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                foreach (var filter in _schemaFilters)
                {
                    filter.Apply(schema, context);
                }
            }
        }

        public class SwaggerFileOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.RequestBody == null)
                {
                    return;
                }

                var uploadFileMediaType = operation.RequestBody.Content
                    .Where(x => x.Key == "multipart/form-data")
                    .Select(x => x.Value)
                    .FirstOrDefault();

                if (uploadFileMediaType == null)
                {
                    return;
                }

                var properties = context.MethodInfo
                    .GetParameters()
                    .SelectMany(p => p.ParameterType.GetProperties());

                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(IFormFile))
                    {
                        var schema = new OpenApiSchema
                        {
                            Type = "string",
                            Format = "binary"
                        };

                        uploadFileMediaType.Schema.Properties[property.Name] = schema;
                    }
                }
            }
        }

        public class ProductIdSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (context.Type == typeof(ProductId))
                {
                    schema.Type = "string";
                    schema.Format = "uuid";
                }
            }
        }

        public class OrderIdSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (context.Type == typeof(OrderId))
                {
                    schema.Type = "string";
                    schema.Format = "uuid";
                }
            }
        }

        public class CategoryIdSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (context.Type == typeof(CategoryId))
                {
                    schema.Type = "string";
                    schema.Format = "uuid";
                }
            }
        }

        public class ImageIdSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (context.Type == typeof(ImageId))
                {
                    schema.Type = "string";
                    schema.Format = "uuid";
                }
            }
        }
        public class ContactIdFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (context.Type == typeof(ContactId))
                {
                    schema.Type = "string";
                    schema.Format = "uuid";
                }
            }
        }
    }
}
