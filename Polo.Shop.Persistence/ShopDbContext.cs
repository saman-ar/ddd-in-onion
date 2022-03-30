using Microsoft.EntityFrameworkCore;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate;
using Polo.Shop.CustomerContext.Infrastructure.Persistence.CustomerAggregate.Mappings;

namespace Polo.Shop.Persistence
{
   public class ShopDbContext : DbContext
   {
      public ShopDbContext(DbContextOptions options) : base(options)
      {      }

      public DbSet<Customer> Customers { get; set; }
      public DbSet<Address> Addresses { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerMapping).Assembly);
         //modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityMappingBase<>).Assembly);
      }

   }
}
