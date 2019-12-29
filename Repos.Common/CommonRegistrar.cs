using Autofac;
using DependencyResolver;
using ProjectDependResolver;
using Repos.DomainModel.Interface.Interfaces;
using ReposServiceConfigurations.Common;
using System.Configuration;

namespace Repos.Common
{
    public class CommonRegistrar 
        : BaseDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public override void Register(ContainerBuilder builder
           , IContainer Container
           , ITypeFinder typeFinder
           , IConfigurationSectionHandler config
           , IConfigOptions options)
        {

            if (!Container.IsRegistered<ICommonInfo>())
                builder
                  .RegisterType<CommonInfo>()
                  .As<ICommonInfo>()
                  .SingleInstance();
        }


        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public override int Order
        {
            get { return int.MaxValue; }
        }

        public override RegType RegisterType =>  RegType.common;
        
    }
}
