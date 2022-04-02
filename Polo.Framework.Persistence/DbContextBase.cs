using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Polo.Framework.Persistence
{
   //public abstract class DbContextBase<TContext> : DbContext where TContext : DbContext
   public abstract class DbContextBase: DbContext

   {
      public DbContextBase(DbContextOptions options) : base(options`)
      { }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         DetectEntityMappings(modelBuilder);
      }
      protected abstract void DetectEntityMappings(ModelBuilder modelBuilder);
   }
}
