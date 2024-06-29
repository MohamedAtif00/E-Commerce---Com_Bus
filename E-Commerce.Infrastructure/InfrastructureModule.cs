using Autofac;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Infrastructure.Domain.product;

using Module = Autofac.Module;

namespace E_Commerce.Infrastructure
{
    public  class InfrastructureModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
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
