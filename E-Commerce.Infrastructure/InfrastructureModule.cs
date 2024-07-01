using Autofac;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Domain.productConfig;
using E_Commerce.SharedKernal.Infrastructure.Interceptor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace E_Commerce.Infrastructure
{
    public  class InfrastructureModule :Module
    {
        private readonly IConfiguration _configuration;

        public InfrastructureModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConvertDomainEventsToOutboxMessagesInterceptor>().SingleInstance();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            builder.Register(context => 
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                var interceptor = context.Resolve<ConvertDomainEventsToOutboxMessagesInterceptor>();

                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default")).AddInterceptors(interceptor);

                return new ApplicationContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();

        }
        //public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        //{
        //    services.AddDbContext<ApplicationContext>(op => {
        //        op.UseSqlServer(configuration.GetConnectionString("default"));
        //    });

        //    var builder

        //    return services;
        //}
    }
}
