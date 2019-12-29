using Autofac;
using DependencyResolver;
using ProjectDependResolver;
using Repos.DomainModel.Interface.Interfaces.Filter;
using RepoUnitTest.Factories;
using System;
using System.Configuration;

namespace RepoUnitTest
{
    public class FilterDependencyRegistrar 
        : ReposDomain.Filters.DependencyRegistrar
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

            ValidAssmPrefix(config);
               


            builder
                .RegisterType<TestFilterFactory>()
                    .As<IFilterFactory>()
                    .InstancePerLifetimeScope();
        }
        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public override int Order
        {
            get { return -1; }
        }
        
    }
}
