using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using E_Commerce.Application;
using E_Commerce.Domain.Model.OrderAggre.Converters;
using E_Commerce.Domain.Model.ProductAggre.Converters;
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
        public static void Main(string[] args)
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
                });
            builder.Services.AddSwaggerGen(c => 
            {
                
                c.SchemaFilter<ProductIdSchemaFilter>();
                c.SchemaFilter<OrderIdSchemaFilter>();
                c.OperationFilter<SwaggerFileOperationFilter>();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("cors");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
