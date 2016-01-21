using Castle.Windsor;
using Castle.Windsor.Installer;
using Pe.ByS.ERP.Aplicacion.Core.Factory;
using Pe.ByS.ERP.Cross.Core.Base;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pe.ByS.Caja.Presentacion
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            BootstrapContainer();
        }

        protected void Application_End()
        {
            container.Dispose();
        }

        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            var entorno = container.Resolve<IEntornoActualAplicacion>();
            entorno.Id = 1;
            entorno.UsuarioSession = "ByS Adminitrador";
            entorno.Terminal = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                                ?? HttpContext.Current.Request.UserHostAddress;
        }

        private static void BootstrapContainer()
        {
            //Database.SetInitializer<SCCDbContextProvider>(new DbContextInitializer());
            //Database.SetInitializer<ApplicationAuditDbContextProvider>(new CreateDatabaseIfNotExists<ApplicationAuditDbContextProvider>());
            container = new WindsorContainer()
                .Install(FromAssembly.InThisApplication());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}