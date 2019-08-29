using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Vehicle_Sales.Service;

namespace Vehicle_Sales
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<ICarDataService, CarDataService>();
            container.RegisterType<ICsvParserService, CsvParserService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}