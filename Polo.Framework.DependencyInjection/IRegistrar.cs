using Castle.Windsor;

namespace Polo.Framework.DependencyInjection
{
   public interface IRegistrar
   {
      void Register(WindsorContainer Container);
   }
}
