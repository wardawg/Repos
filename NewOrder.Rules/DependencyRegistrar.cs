using Autofac;
using DependencyResolver;
using ProjectDependResolver;
using System.Configuration;

namespace ReposDomain.Rules
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
        public override int Order
        {
            get { return 0; }
        }
    }
}
