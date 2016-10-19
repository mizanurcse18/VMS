using System.Web.Http;
//using System.Web.Mvc;
using Microsoft.Practices.Unity;
//using Microsoft.Practices.Unity.Mvc;
using Unity.WebApi;
using PS.Framework.Dependency;

namespace PS.Web.UI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyRegistrar.RegisterComponents(container);

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //container.RegisterInstance(typeof(HttpConfiguration), GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);//Unity.WebApi.UnityDependencyResolver(container);

        }

        #endregion
    }
}
