namespace Polo.Framework.Core.DependencyInjection
{
  public static class ServiceLocator
  {
    public static void Initial (IDiContainer container)
    {
      if (Current == null)
        Current = container;
    }
    public static IDiContainer Current { get; private set; }
  }
}
