using Polo.Framework.Core.DependencyInjection;
using Castle.Windsor;

namespace Polo.Framework.DependencyInjection
{
  public class DiContainer : IDiContainer
  {
    private readonly WindsorContainer _container;
    public DiContainer(WindsorContainer container)
    {
      _container = container;
    }

    public T Resolve<T>()
    {
      return _container.Resolve<T>();
    }
  }
}
