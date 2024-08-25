using E_Commerce.Identity.Domain.Model;
using E_Commerce.Identity.Domain.Model.UserAggre;
using E_Commerce.Identity.Domain.Model.UserRoleAggre;
using E_Commerce.SharedKernal.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Identity.Infrastructure.Data
{
    public class ApplicationUserContext : IdentityDbContext<User,UserRole,Guid>
    {
        private readonly List<string> _errors= new();
        public ApplicationUserContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<UserRole> roles { get; set; }

        public IReadOnlyCollection<string> errors => _errors.AsReadOnly();

        public void AddError(string error)
        {
            _errors.Add(error);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
