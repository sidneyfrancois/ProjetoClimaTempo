using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Weather.Data.Context;
using Weather.MVC.Repository;

namespace Weather.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<MyDbContext, MyDbContext>();
            container.RegisterType<CidadeRepository, CidadeRepository>();
            container.RegisterType<PrevisaoClimaRepository, PrevisaoClimaRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}