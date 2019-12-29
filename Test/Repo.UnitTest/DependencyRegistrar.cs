using Autofac;
using DependencyResolver;
using ProjectDependResolver;
using Repos.DomainModel.Interface.Interfaces;
using ReposCore.Caching;
using ReposData.Repository;
using ReposDomain.Handlers.Handlers;
using ReposServiceConfigurations.ServiceTypes.Base;
using RepoUnitTest.Context;
using RepoUnitTest.Services.Handler;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace RepoUnitTest

{
    public class DependencyRegistrar : BaseDependencyRegistrar
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

          //  ModelValidatorProviders.Providers.Add(new ReposDomain.Validation.Validators.Base.ReposModelValidatorProviderMvc());

            //  var appConfig = ConfigurationManager.OpenExeConfiguration("C:\\VSProjects\\Repos\\bin\\ReposServiceConfigure.dll");

            // var local = appConfig.Sections.Cast<ConfigurationSection>().Where(s => s.SectionInformation.Name == "ServiceConfig");
            var appConfig = ConfigurationManager.OpenExeConfiguration(this.GetType().Assembly.Location);

            //Assembly.GetExecutingAssembly().Location);

            var localconfig = appConfig.GetSection("ReposConfig") as IConfigurationSectionHandler;




            builder
             .Register<IDbContext>(c => new TestDbContext("TestDbContext"))
                 .InstancePerLifetimeScope();

            //builder
            //.RegisterType<TestGenericHandler>()
            //.As<IServiceGenericHandler>()
            //.InstancePerLifetimeScope();


            typeof(IBaseService).Assembly.GetTypes()
             .Where(t => typeof(IBaseService).IsAssignableFrom(t));

            typeof(IBaseService).Assembly.GetTypes()
            .Where(t => typeof(IBaseService).IsAssignableFrom(t)
                         && !t.IsInterface && !t.IsGenericType)
            .ToList();
           

            builder
                .RegisterType<PerRequestCacheManager>()
                .As<ICacheManager>().Named<ICacheManager>("repos_cache_per_request")
                .InstancePerLifetimeScope();
            builder
                .RegisterType<MemoryCacheManager>()
                .As<ICacheManager>()
                .Named<ICacheManager>("repos_cache_static")
                .SingleInstance();

            
            builder
                .RegisterType<CacheService>()
                .As<ICacheService>()
                .InstancePerLifetimeScope();

            // overide interfaces/handlers here
            builder
                .RegisterType<TestSubCategoryHandler>()
                .As<ISubCategoryHandler>()
                .InstancePerLifetimeScope();

            Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(IServiceHandler).IsAssignableFrom(t))
           .Union(
             typeof(IServiceHandler).Assembly.GetTypes())
            .Where(t => typeof(IServiceHandler).IsAssignableFrom(t))
            .Where(g => g.GetInterfaces()
            .Any()) 
            .Select(s => new
            {
                source = GetTestType(s)
                ,
                target = GetInterface(s)

            }).ToList()
            .ForEach(b => {

                if (b.target != null && b.source != null)
                    builder
                            .RegisterType(b.source)
                            .As(b.target)
                            .InstancePerLifetimeScope();
            }
                );
      
        }

        Type GetInterface(Type type)
        {

            //ISubCategoryHandler
            //IServiceHandler

            Type t =
                    new Type[] {
                                  type.GetInterface(string.Format("I{0}", type.Name), true)
                                 ,type.GetInterfaces().FirstOrDefault()
                                 ,type.GetInterface("IServiceHandler", true)
                               }
                    .Where(w=> w != null && type != w)
                    .FirstOrDefault();

            return t;
        }
        Type TypeGetGenericType(Type type)
        {
            //typeof(DomainBaseEdits).Assembly.GetTypes().Where(t => typeof(DomainBaseEdits).IsAssignableFrom(t)).Where(i => i.GetInterfaces().Any(g => g.IsGenericType && g.GetGenericTypeDefinition() == typeof(IServiceEntityEdit<>) && g.GetType().GetInterfaces().Count() != 0)).ToList()[0].GetInterfaces().GetType()
            Type t = type.GetInterfaces().FirstOrDefault();
            return t;
        }

        Type GetTestType(Type type)
        {
           // Assembly.GetExecutingAssembly().GetTypes()
           //     .Where(t => typeof(IServiceHandler).IsAssignableFrom(t))
           //.Union(
           //  typeof(IServiceHandler).Assembly.GetTypes())
           // .Where(t => typeof(IServiceHandler).IsAssignableFrom(t))

            Type t = Assembly.GetExecutingAssembly()
                     .GetTypes()
                     .Where(a => a.Name == string.Format("Test{0}", type.Name)
                     || a.Name == string.Format("{0}", type.Name)).FirstOrDefault();
                        
            return t;
        }


        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public override int Order
        {
            get { return int.MaxValue; }
        }

        public override RegType RegisterType { get { return RegType.test; } }
    }
}
