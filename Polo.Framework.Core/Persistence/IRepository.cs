using Polo.Framework.Core.Domain;

namespace Polo.Framework.Core.Persistence
{
   public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot<TAggregateRoot>
   {
   }
}
