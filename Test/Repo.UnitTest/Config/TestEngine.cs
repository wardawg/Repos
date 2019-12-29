using System;
using Autofac;
using System.Configuration;
using ReposCore.Infrastructure;
using ReposCore.Infrastructure.DependencyManagement;
using ProjectDependResolver;
using System.Collections.Generic;
using WebAppTypeFinder = ProjectDependResolver.WebAppTypeFinder;

namespace RepoUnitTest.Config
{
    public class TestEngine : IEngine
    {
        private ContainerManager _containerManager;

        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        ReposCore.Infrastructure.DependencyManagement.ContainerManager IEngine.ContainerManager => throw new NotImplementedException();

        public void Initialize(IConfigurationSectionHandler config)
        {
            RegisterDependencies(config);
        }
        protected virtual void RegisterDependencies(IConfigurationSectionHandler config)
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();
            this._containerManager = new ContainerManager(container);
          
                //dependencies
             var typeFinder = new WebAppTypeFinder();

            builder = new ContainerBuilder(); 
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();
            builder.Update(container);
    


            foreach (var dependencyRegistrar
                           in new Type[]{
                               typeof(DependencyRegistrar)
                              ,typeof(Repos.DomainModel.Interface.DependencyRegistrar)
                              ,typeof(FilterDependencyRegistrar)
                              ,typeof(ReposDomain.Handlers.DependencyRegistrar)
                              ,typeof(ReposDomain.Filters.DependencyRegistrar)
                    //          ,typeof(ValidationDependencyRegistrar)
                      //        ,typeof(ReposAdmin.ValidationDependencyRegistrar)
                      
                           })
              
            {
                var dep = (IDependencyRegistrar)Activator.CreateInstance(dependencyRegistrar);
                builder = new ContainerBuilder();
                dep.Register(builder, container, null, config,new TestClassConfigOptions());
                builder.Update(container);
            }


        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(bool AllowNull = false) where T : class
        {
            return ContainerManager.Resolve<T>();
        }

       public IEnumerable<T> ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        public void Initialize(ContainerBuilder container)
        {
            throw new NotImplementedException();
        }
    }
}
