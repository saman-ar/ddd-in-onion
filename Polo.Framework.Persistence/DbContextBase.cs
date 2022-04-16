using Microsoft.EntityFrameworkCore;

namespace Polo.Framework.Persistence
{
   //public abstract class DbContextBase<TContext> : DbContext where TContext : DbContext
   public abstract class DbContextBase: DbContext

   {
      public DbContextBase(DbContextOptions options) : base(options)
      { }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         DetectEntityMappings(modelBuilder);

         base.OnModelCreating(modelBuilder);
      }
      protected abstract void DetectEntityMappings(ModelBuilder modelBuilder);

   }
}
