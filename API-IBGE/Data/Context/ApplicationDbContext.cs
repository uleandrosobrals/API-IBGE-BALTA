using API_IBGE.Data.Mappings;
using API_IBGE.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace API_IBGE.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Location> Locations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocationMapping());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(e => new { e.LoginProvider, e.ProviderKey });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
        }

    }
}
