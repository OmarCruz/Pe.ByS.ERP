using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Pe.ByS.ERP.Cross.Core.Base;
using Pe.ByS.ERP.Cross.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.ByS.ERP.Aplicacion.Core.Factory
{
    public class EnvironmentFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(Component.For<IEntornoActualAplicacion>()
                .ImplementedBy<EntornoActualAplicacion>()
                .LifestylePerWebRequest());
        }
    }
}
