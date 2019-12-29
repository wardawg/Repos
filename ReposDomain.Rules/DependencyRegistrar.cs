using Autofac;
using DependencyResolver;
using ProjectDependResolver;
using ReposServiceConfigurations;
using ReposServiceConfigurations.ServiceTypes.Enums;
using ReposServiceConfigurations.ServiceTypes.Rules;
using System.Configuration;
using IModelRule = Repos.DomainModel.Interface.Interfaces.IModelRule;

namespace ReposDomain.Rules
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


            ValidAssmPrefix(config);
                

            if (!Container.IsRegistered<IRule>())
                builder
                .RegisterType<DomainRule>()
                .As<IRule>()
                .InstancePerLifetimeScope();


            SetDependency<IEntityRule, IModelRule>(
                builder
              , Container
              , this
                  .GetType()
                  .Assembly
                  .GetTypes()
              , EnumServiceTypes.Rules
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

        public override RegType RegisterType { get { return RegType.rules; } }

    }
}
