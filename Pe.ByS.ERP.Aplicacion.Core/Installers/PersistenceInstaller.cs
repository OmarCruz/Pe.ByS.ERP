using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Pe.ByS.ERP.Aplicacion.Core.Factory;

namespace Pe.ByS.ERP.Aplicacion.Core.Installers
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<PersistenceFacility>();
        }
    }
}
