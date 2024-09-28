using Autofac;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ContactAggre;
using E_Commerce.Domain.Model.CustomerAggre;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.Domain.Model.SpecificationAggre;
using E_Commerce.Domain.Model.SuperCategoryAggre;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Domain;
using E_Commerce.Infrastructure.Domain.AdministrationConfig;
using E_Commerce.Infrastructure.Domain.CategoryConfig;
using E_Commerce.Infrastructure.Domain.ContactConfig;
using E_Commerce.Infrastructure.Domain.CustomerConfig;
using E_Commerce.Infrastructure.Domain.OrderConfig;
using E_Commerce.Infrastructure.Domain.productConfig;
using E_Commerce.Infrastructure.Domain.ShipmentInformationConfig;
using E_Commerce.Infrastructure.Domain.SpecialProductsConfig;
using E_Commerce.Infrastructure.Domain.SpecificationConfig;
using E_Commerce.Infrastructure.Domain.SuperCategoryConfig;
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
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<SuperCategoryRepository>().As<ISuperCategoryRepository>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<SpecificationRepository>().As<ISpecificationRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<ImageRepository>().As<IImageRepository>();
            builder.RegisterType<AdministrationRepository>().As<IAdministrationRepository>();
            builder.RegisterType<SpecialProductsRepository>().As<ISpecialProductsRepository>();
            builder.RegisterType<ContactRepository>().As<IContactRepository>();
            builder.RegisterType<ShipmentInformationRepository>().As<IShipmentInformationRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.Register(context =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                var interceptor = context.Resolve<ConvertDomainEventsToOutboxMessagesInterceptor>();

                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default")).AddInterceptors(interceptor);

                return new ApplicationContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope(); // Register as scoped



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
