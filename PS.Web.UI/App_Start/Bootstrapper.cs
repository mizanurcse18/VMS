using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
//using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using PS.Data.Infrastructure;

namespace PS.Web.UI
{
    public static class Bootstrapper
    {
        public static void Start(HttpConfiguration config)
        {
            //SetAutofacContainer();
            //Configure AutoMapper
            //AutoMapperConfiguration.Configure();

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();

            // builder.RegisterAssemblyTypes(typeof(LoginInfoRepository).Assembly)
            // .Where(t => t.Name.EndsWith("Repository"))
            // .AsImplementedInterfaces().InstancePerHttpRequest();

            // builder.RegisterAssemblyTypes(typeof(LoginInfoService).Assembly)
            //.Where(t => t.Name.EndsWith("Service"))
            //.AsImplementedInterfaces().InstancePerHttpRequest();

            //builder.RegisterAssemblyTypes(typeof(DefaultFormsAuthentication).Assembly)
            //.Where(t => t.Name.EndsWith("Authentication"))
            //.AsImplementedInterfaces().InstancePerHttpRequest();

            //builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>( new SampleEntities())))
            //.As<UserManager<ApplicationUser>>().InstancePerHttpRequest();

            builder.RegisterWebApiModelBinderProvider();
            IContainer container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerDependency();

           // builder.RegisterAssemblyTypes(typeof(LoginInfoRepository).Assembly)
           // .Where(t => t.Name.EndsWith("Repository"))
           // .AsImplementedInterfaces().InstancePerHttpRequest();

           // builder.RegisterAssemblyTypes(typeof(LoginInfoService).Assembly)
           //.Where(t => t.Name.EndsWith("Service"))
           //.AsImplementedInterfaces().InstancePerHttpRequest();

            //builder.RegisterAssemblyTypes(typeof(DefaultFormsAuthentication).Assembly)
            //.Where(t => t.Name.EndsWith("Authentication"))
            //.AsImplementedInterfaces().InstancePerHttpRequest();

            //builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>( new SampleEntities())))
            //.As<UserManager<ApplicationUser>>().InstancePerHttpRequest();

            builder.RegisterWebApiModelBinderProvider();
            IContainer container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);
        }
    }
}