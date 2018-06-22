using Microsoft.Practices.ServiceLocation;
using Mirabeau.Infra.CrossCutting.IoC;
using Mirabeau.UI.MVC.AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace Mirabeau.UI.MVC
{
    public class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            SimpleInjectorBootstrapper.RegisterServices(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocator(container));

            var mapper = AutoMapperConfig.CreateMapperConfiguration();

            container.RegisterSingleton(mapper);

            container.Register(() => mapper.CreateMapper(container.GetInstance), Lifestyle.Scoped);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}