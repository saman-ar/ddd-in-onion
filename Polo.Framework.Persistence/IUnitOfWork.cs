namespace Polo.Framework.Persistence
{
   public interface IUnitOfWork
   {
      void Commit();
      void RollBack();
   }
}
