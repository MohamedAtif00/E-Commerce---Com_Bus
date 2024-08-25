using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Module = Autofac.Module;
using E_Commerce.SharedKernal.Infrastructure.Interceptor;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Identity.Infrastructure.Data;

namespace E_Commerce.Identity.Infrastructure
{
    public class IdentityInfrastructureModule : Module
    {
        private readonly IConfiguration _configuration;

        public IdentityInfrastructureModule(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationUserContext>();

                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Identity"));

                return new ApplicationUserContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope(); // Register as scoped
        }

    }
}
