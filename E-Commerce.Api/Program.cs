using Autofac;
using Autofac.Extensions.DependencyInjection;
using E_Commerce.Application;
using E_Commerce.Infrastructure;
using E_Commerce.SharedKernal.Infrastructure.Interceptor;

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
                // register intrastructure
                containerBuilder.RegisterModule(new InfrastructureModule(configuration));
            });
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(ApplicationModule).Assembly);
            });
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
