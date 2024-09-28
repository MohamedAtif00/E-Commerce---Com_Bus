using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ContactAggre;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Domain.Model.ProductOptionAggre;
using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.Domain.Model.SpecificationAggre;
using E_Commerce.Domain.Model.SuperCategoryAggre;
using E_Commerce.Identity.Infrastructure.Data;
using E_Commerce.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data
{
    public class ApplicationContext : ApplicationUserContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> categories   { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Image> images { get; set; }    
        public DbSet<ProductOption> productsOption { get; set; }
        public DbSet<Specification> specifications { get; set; }
        public DbSet<SuperCategory> superCategories { get; set; }
        public DbSet<Administration> administrations { get; set; }
        public DbSet<ShipmentInformation> ShipmentInformation { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<SpecialProducts> SpecialProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
