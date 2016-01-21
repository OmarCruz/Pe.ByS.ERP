﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Pe.ByS.ERP.Aplicacion.Core.Installers
{
    public class DomainServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var assemblyName = System.Configuration.ConfigurationManager.AppSettings["DomainServiceAssembly"];
            if (assemblyName != null && assemblyName != "")
            {
                container.Register(Classes.FromAssemblyNamed(assemblyName)
                                    .Pick()
                                    .LifestyleTransient().WithService.DefaultInterfaces());
            }
        }
    }
}
