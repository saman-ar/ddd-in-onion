using Microsoft.EntityFrameworkCore;
using Polo.Framework.Persistence;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate;
using Polo.Shop.CustomerContext.Infrastructure.Persistence.CustomerAggregate.Mappings;

namespace Polo.Shop.Persistence
{
   //public class ShopDbContext : DbContextBase<ShopDbContext>
   public class ShopDbContext : DbContextBase

   {
      public ShopDbContext(DbContextOptions options) : base(options)
      {      }

      public DbSet<Customer> Customers { get; set; }
      public DbSet<Address> Addresses { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
      }

      protected override void DetectEntityMappings(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerMapping).Assembly);
         //modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityMappingBase<>).Assembly);
      }


   }
}
