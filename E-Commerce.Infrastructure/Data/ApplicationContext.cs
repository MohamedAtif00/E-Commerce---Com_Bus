using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.OrderAggre;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Domain.Model.ProductOptionAggre;
using E_Commerce.Domain.Model.SpecificationAggre;
using E_Commerce.Domain.Model.SuperCategoryAggre;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> categories   { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductOption> productsOption { get; set; }
        public DbSet<Specification> specifications { get; set; }
        public DbSet<SuperCategory> superCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
