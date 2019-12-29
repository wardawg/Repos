using Autofac;
using ProjectDependResolver;
using ReposServiceConfigurations.ServiceTypes.Edits;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System;
using DependencyResolver;
using ReposServiceConfigurations;
using ReposServiceConfigurations.ServiceTypes.Enums;

namespace ReposDomain.Edits
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

            var RegTypes = ResolveTypes<IDomainEdit>(typeFinder, options);

          
            SetDependency<IDomainEdit, IServiceEntityEdit>(
                 builder
               , Container
               , RegTypes
               , EnumServiceTypes.Edits
               , options
              );


        }


        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public override int Order
        {
            get { return int.MaxValue-1; }
        }

        public override RegType RegisterType {get{return RegType.edits;}}
    }
}
