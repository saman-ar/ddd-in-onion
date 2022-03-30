using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Polo.Shop.Persistence
{
   public class ShopContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
   {
      public ShopDbContext CreateDbContext(string[] args)
      {
         var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();
         var connectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=Polo.Shop ;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
         optionsBuilder.UseSqlServer(connectionString);

         return new ShopDbContext(optionsBuilder.Options);
      }
   }
}
