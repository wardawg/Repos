using Autofac;
using DependencyResolver;
using NewOrder.Common;
using ProjectDependResolver;
using Repos.Common;
using Repos.DomainModel.Interface.Interfaces;
using System.Configuration;

namespace NewOrders.Common
{
    public class DependencyRegistrar 
        : CommonRegistrar
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

            var build = new ContainerBuilder();



                builder
                  .RegisterType<NewOrderCommonInfo>()
                  .As<ICommonInfo>()
                  .SingleInstance();

            //build.Update(Container);
              
        //    base.Register(builder, Container, typeFinder, config, options);
            
        }


        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public override int Order
        {
            get { return 0; }
        }



}
}
