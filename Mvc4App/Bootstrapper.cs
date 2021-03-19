using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using Mvc4App.Controllers;
using Mvc4App.DataAccess;

namespace Mvc4App
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

        // register all your components with the container here
        // e.g. container.RegisterType<ITestService, TestService>();   
        
        RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {

        container.RegisterType<IUnitOfWork, UnitOfWork>(new TransientLifetimeManager());
    }
  }
}