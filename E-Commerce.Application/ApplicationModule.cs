using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR;
using System.Reflection;

using Autofac.Core;
using Autofac.Features.Variance;
using MediatR.Pipeline;
using E_Commerce.Application.Query.ProductQuery.GetAllProducts;
using AutoMapper;

namespace E_Commerce.Application
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register MediatR
            builder.RegisterAssemblyTypes(ThisAssembly)
                   .AsClosedTypesOf(typeof(IRequestHandler<,>))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                   .AsClosedTypesOf(typeof(INotificationHandler<>))
                   .AsImplementedInterfaces();

            // Register AutoMapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                // Register all AutoMapper profiles in the assembly
                cfg.AddMaps(ThisAssembly);
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
    

