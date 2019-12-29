using Autofac;
using DependencyResolver;
using ProjectDependResolver;
using System.Configuration;

namespace RepoUnitTest
{
    public class RuleDependencyRegistrar
        : ReposDomain.Rules.DependencyRegistrar
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
         
           
            base.Register(builder, Container, typeFinder, config, options);

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
