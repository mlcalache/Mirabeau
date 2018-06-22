using Mirabeau.Application.Services;
using Mirabeau.Domain.Interfaces.Services;
using Mirabeau.Infra.Service.AirportList;
using SimpleInjector;

namespace Mirabeau.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBootstrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IAirportListService, AirportListService>(Lifestyle.Scoped);
            container.Register<ILoginService, LoginService>(Lifestyle.Scoped);
            container.Register<IAirportExhibitionService, AirportExhibitionService>(Lifestyle.Scoped);
        }
    }
}