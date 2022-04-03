using Microsoft.EntityFrameworkCore;
using Polo.Framework.Domain;
using System;
using System.Linq;

namespace Polo.Framework.Persistence
{
   public abstract class RepositoryBase<TAggregateRoot> where TAggregateRoot : EntityBase  , IAggregateRoot<TAggregateRoot>, new()
   {
      protected readonly DbContextBase _context;
      protected RepositoryBase(DbContextBase context)
      {
         _context = context;
      }

      protected IQueryable<TAggregateRoot> SetWithIncludeExpressions
      {
         get
         {
            var set = _context.Set<TAggregateRoot>().AsQueryable();//.AsQueryable();

            ///Customer has a private parameterless constractor that i need change
            ///to public for instantiate in this line of code
            var includeExpressions = new TAggregateRoot().GetIncludeExpression();
            foreach (var predicate in includeExpressions)
            {
               set = set.Include(predicate);
            }

            return set;
         }
      }

      protected DbSet<TAggregateRoot> Set
      {
         get
         {
            return _context.Set<TAggregateRoot>();
         }
      }


      public TAggregateRoot GetById(Guid id)
      {
         return SetWithIncludeExpressions.Single(t => t.Id == id);

      }
   }
}
