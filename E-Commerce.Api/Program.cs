using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using E_Commerce.Api.Extension;
using E_Commerce.Api.seed;
using E_Commerce.Application;
using E_Commerce.Domain.Model.CategoryAggre.Converters;
using E_Commerce.Domain.Model.ContactAggre;
using E_Commerce.Domain.Model.ContactAggre.Converters;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.OrderAggre.Converters;
using E_Commerce.Domain.Model.ProductAggre.Converters;
using E_Commerce.Identity.Infrastructure;
using E_Commerce.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.Text.Json.Serialization;
using static E_Commerce.Api.Swagger.SchemaFilters;



namespace E_Commerce.Api
{
    public class Program
    {
        public static  async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            // Add services to the container.

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                // register infrastructure
                containerBuilder.RegisterModule(new InfrastructureModule(configuration));
                containerBuilder.RegisterModule(new ApplicationModule());
            });

            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(ApplicationModule).Assembly);
            });

            builder.Services.AddIdentityService(configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("cors", builder =>
                {
                    builder.AllowAnyOrigin()// Replace with your frontend URL
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                });
            });

            builder.Services.AddMvc()
                .AddJsonOptions(op => 
                {
                    var enumConverter = new JsonStringEnumConverter();
                    op.JsonSerializerOptions.Converters.Add(enumConverter);
                })
            .AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );

            builder.Services.AddControllers()
                .AddJsonOptions(op => 
                {
                    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddNewtonsoftJson(op => 
                {
                    op.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    op.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    op.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    op.SerializerSettings.Converters.Add(new ProductConverter.ProductIdJsonConverter());
                    op.SerializerSettings.Converters.Add(new OrderConverter.OrderIdJsonConverter());
                    op.SerializerSettings.Converters.Add(new CategoryConverter.CategoryIdJsonConverter());
                    op.SerializerSettings.Converters.Add(new ImageConverter.ImageIdJsonConverter());
                    op.SerializerSettings.Converters.Add(new ContactConverter.ContactIdJsonConverter());
                });
            builder.Services.AddSwaggerGen(c => 
            {
                
                c.SchemaFilter<ProductIdSchemaFilter>();
                c.SchemaFilter<OrderIdSchemaFilter>();
                c.SchemaFilter<CategoryIdSchemaFilter>();
                c.SchemaFilter<ImageIdSchemaFilter>();
                c.SchemaFilter<ContactIdFilter>();
                c.OperationFilter<SwaggerFileOperationFilter>();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection(); // Redirect HTTP to HTTPS

            app.UseStaticFiles(); // Serve static files (like Angular files in wwwroot)

            app.UseRouting(); // Enables routing

            app.UseCors("cors"); // Apply CORS policy

            app.UseAuthorization(); // Authorization should be after routing and CORS

            // Enable Swagger and Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI();

            // Map controller routes directly
            app.MapControllers();

            // Map fallback to serve Angular app (for client-side routing)
            app.MapFallbackToFile("index.html");

            // Call the seeding method (in case of first-time or updated deployment)
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await AdminSeeder.SeedAdminUserAsync(services, configuration);
            }

            // Run the application
            await app.RunAsync();

        }
    }
}
