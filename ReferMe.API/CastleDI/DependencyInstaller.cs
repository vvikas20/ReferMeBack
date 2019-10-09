using System;
using ReferMe.Common.Contracts;
using ReferMe.Common.Implementations;
using ReferMe.DAL.Contracts;
using ReferMe.DAL.Implementations;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http.Controllers;


namespace ReferMe.API.CastleDI
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                        Component.For<ILogService>()
                            .ImplementedBy<LogService>()
                            .LifeStyle.PerWebRequest(),

                        Component.For<IDatabaseFactory>()
                            .ImplementedBy<DatabaseFactory>()
                            .LifeStyle.PerWebRequest(),

                        Component.For<IUnitOfWork>()
                            .ImplementedBy<UnitOfWork>()
                            .LifeStyle.PerWebRequest(),

                        Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient(),

                        Classes.FromAssemblyNamed("ReferMe.Service")
                            .Where(type => type.Name.EndsWith("Service")).WithServiceAllInterfaces().LifestylePerWebRequest(),

                        Classes.FromAssemblyNamed("ReferMe.Repository")
                            .Where(type => type.Name.EndsWith("Repository")).WithServiceAllInterfaces().LifestylePerWebRequest()
                        );
        }

    }
}