using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Bede.Middleware.Clients.Base;
using Bede.Middleware.Clients.Base.Http;
using Bede.Middleware.Clients.Base.Web;
using Bede.Middleware.Clients.Security;
using MvcWebRole1.Controllers;
using System.Web.Http;

namespace MvcWebRole1.App_Start
{
    /// <summary>
    /// </summary>
    /// DependencyInjectionConfig
    public class DependencyInjectionConfig
    {
        /// <summary>
        /// http://alexmg.com/post/2012/06/08/Autofac-262859-and-ASPNET-MVC-4-RC-Integrations-Released.aspx
        /// 
        /// This is the composition root for the Web API application
        /// </summary>
        public static void RegisterDependencyInjection(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterType<ConfigCommonServiceSettings>().As<ICommonServiceSettings>().InstancePerLifetimeScope();
            builder.RegisterType<ODataHttpClientHelper>().As<IWebClientHelper>();
            builder.RegisterType<HttpWebRequestFactory>().As<IWebRequestFactory>();
            builder.RegisterType<MSHttpClientFactory>().As<IHttpClientFactory>();
            builder.RegisterType<MembershipClient>().As<IMembershipClient>().InstancePerHttpRequest();

            var container = builder.Build();

            // Set the dependency resolver implementation.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}