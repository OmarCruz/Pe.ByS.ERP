using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Mvc;

namespace Pe.ByS.ERP.Aplicacion.Core.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var assemblyName = System.Configuration.ConfigurationManager.AppSettings["ConstrollerAssembly"];
            if (assemblyName != null && assemblyName != "")
            {
                container.Register(Classes.FromAssemblyNamed(assemblyName)
                                    .BasedOn<IController>()
                                    .LifestyleTransient());
            }
        }
    }
}
