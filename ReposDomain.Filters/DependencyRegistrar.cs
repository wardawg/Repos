using Autofac;
using DependencyResolver;
using ProjectDependResolver;
using Repos.DomainModel.Interface.Interfaces.Filter;
using ReposServiceConfigurations;
using ReposServiceConfigurations.ServiceTypes.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ReposDomain.Filters
{
    public class DependencyRegistrar
        : ServiceDependencyRegister
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
            
            var RegTypes = ResolveTypes<IFilter>(typeFinder, options);

           
            if (!Container.IsRegistered<IFilterFactory>())
                builder
                    .RegisterType<FilterFactory>()
                    .As<IFilterFactory>()
                    .InstancePerLifetimeScope();

            if (!Container.IsRegistered<ClientConstBase>())
            builder
                .RegisterInstance(new ClientConstBase())
                .As<ClientConstBase>()
                .SingleInstance();

            if (!Container.IsRegistered<IFilterConstants>())
                builder
                .RegisterType<FilterConstants>()
                .As<IFilterConstants>()
                .SingleInstance();
                        
            
            SetDependency<IDomainActionFilter,INullResolver>(
                 builder
                 , Container
                  , RegTypes
                  , EnumServiceTypes.Filters
                  , options
                );
        }


        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public override int Order
        {
            get { return int.MaxValue; }
        }

        public override RegType RegisterType { get { return RegType.filters; } }
        
    }
}
