using Polo.Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.CustomerContext.Infrastructure.Persistence
{
   public class UnitOfWork : IUnitOfWork
   {
      private readonly DbContextBase _context;
      public UnitOfWork(DbContextBase context)
      {
         _context = context;
      }
      public void Commit()
      {
         _context.SaveChanges();
      }

      public void RollBack()
      {
         _context.Dispose();
      }
   }
}
