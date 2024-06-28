using Autofac;
using E_Commerce.Domain.Abstraction;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Domain.product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
