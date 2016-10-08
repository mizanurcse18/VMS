using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.Unity;
using PS.Data;
using PS.Data.Infrastructure;
using PS.Framework.Authentication;
using PS.Infrastructure.Authentication;
using PS.Infrastructure.Caching;
using PS.Infrastructure.Configuration;
using PS.Service;
using DatabaseFactory = Microsoft.Practices.EnterpriseLibrary.Data.DatabaseFactory;

namespace PS.Framework.Dependency
{
    public class DependencyRegistrar
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            container.RegisterType<HttpContextBase>(new PerRequestLifetimeManager(), new InjectionFactory(c =>
            {
                return new HttpContextWrapper(HttpContext.Current);
            }));

            container.RegisterType<HttpRequestBase>(new InjectionFactory(c =>
            {
                return container.Resolve<HttpContextBase>().Request;
            }));

            //container.RegisterPerWebRequest<IAuthenticationManager>(() => AdvancedExtensions.IsVerifying(container) ? new OwinContext(new Dictionary<string, object>()).Authentication : HttpContext.Current.GetOwinContext().Authentication);

            container.RegisterType<ICacheManager, MemoryCacheManager>(new ContainerControlledLifetimeManager());
            container.RegisterType<Func<HttpSessionStateBase>>(new PerRequestLifetimeManager(),
                new InjectionFactory(a => new Func<HttpSessionStateBase>(() => new HttpSessionStateWrapper(HttpContext.Current.Session))));
            container.RegisterType<IAuthenticationContext, AuthenticationContext>(
                new PerRequestLifetimeManager());
            container.RegisterType<Func<HttpContextBase>>(new PerRequestLifetimeManager(),
                new InjectionFactory(a => new Func<HttpContextBase>(() => new HttpContextWrapper(HttpContext.Current))));

            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IWorkContext, WebWorkContext>(new PerRequestLifetimeManager());
            //container.RegisterType<IAuthenticationService, AuthenticationService>();
            //config.DependencyResolver = new UnityResolver(container);
            //SetupDatabaseFactory();

            //ApplicationSettingsFactory.InitializeApplicationSettingsFactory(container.Resolve<IApplicationSettings>());
        }

        public static void SetupDatabaseFactory()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
        }
    }
}