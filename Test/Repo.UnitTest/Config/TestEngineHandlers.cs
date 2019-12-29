using Autofac;
using ProjectDependResolver;
using ReposCore.Infrastructure;
using ReposCore.Infrastructure.DependencyManagement;
using ReposData.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WebAppTypeFinder = ProjectDependResolver.WebAppTypeFinder;

namespace RepoUnitTest.Config
{
    public class TestEngineHandler : IEngine
    {
        private ContainerManager _containerManager;

        

        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }
        
        public void Initialize(IConfigurationSectionHandler config)
        {
            Initialize(config, new TestClassConfigOptions());
        }
            
        public void Initialize(IConfigurationSectionHandler config
                                , TestClassConfigOptions opts = null)
        {
            if (opts == null)
                opts = new TestClassConfigOptions();

            RegisterDependencies(config,opts);
        }

        //public interface ITestEntityMapping
        //{

        //}

        //public class TestEntityMapping
        //    : ITestEntityMapping
        //{

        //}


        //public class TestEntityMapping2
        //            : TestEntityMapping
        //{

        //}

        ////public class TestEntityMapping3
        ////            : TestEntityMapping2
        ////{

        ////}

        ////public class TestEntityMapping4
        ////            : ITestEntityMapping
        ////{

        ////}

        ////public class TestEntityMapping5
        ////        : ITestEntityMapping
        ////{

        ////}

        protected virtual void RegisterDependencies(IConfigurationSectionHandler config, TestClassConfigOptions opts = null)
        {
            if (opts == null)
                opts = new TestClassConfigOptions();


            var builder = new ContainerBuilder();
            var container = builder.Build();
            this._containerManager = new ContainerManager(container);
          
                //dependencies
             var typeFinder = new WebAppTypeFinder();

            builder = new ContainerBuilder(); 
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            builder
                .Register<IDbContext>(c => new ReposContext("ReposContext"))
                .InstancePerLifetimeScope();

            //builder.RegisterType<TestEntityMapping>()
            //    .As<ITestEntityMapping>()
            //    .InstancePerLifetimeScope();

            builder.Update(container);

            typeFinder.AssemblySkipLoadingPattern =
             "^Test^System" + "|^mscorlib" + "|^Microsoft" +
             "|^AjaxControlToolkit" + "|^Antlr3" + "|^Autofac" +
             "|^AutoMapper" + "|^Castle" + "|^ComponentArt" +
             "|^CppCodeProvider" + "|^DotNetOpenAuth" + "|^EntityFramework" +
             "|^EPPlus" + "|^FluentValidation" + "|^ImageResizer" +
             "|^itextsharp" + "|^log4net" + "|^MaxMind" +
             "|^MbUnit" + "|^MiniProfiler" + "|^Mono.Math" +
             "|^MvcContrib" + "|^Newtonsoft" + "|^NHibernate" +
             "|^nunit" + "|^Org.Mentalis" + "|^PerlRegex" +
             "|^QuickGraph" + "|^Recaptcha" + "|^Remotion" +
             "|^RestSharp" + "|^Rhino" + "|^Telerik" +
             "|^Iesi" + "|^TestDriven" + "|^TestFu" +
             "|^UserAgentStringLibrary" + "|^VJSharpCodeProvide" + "r|^WebActivator" +
             "|^WebDev" + "|^WebGrease";

      
            var drInstances = new List<IDependencyRegistrar>();

            var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>().AsEnumerable();
          
            
            foreach (var drType in drTypes)
                drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));

            foreach (var regtype in Enum.GetValues(typeof(RegType)))
            {
                foreach (var dependencyRegistrar in drInstances
                     .Where(w => w.RegisterType.ToString() == regtype.ToString())
                             .OrderBy(o => o.Order))
                {
                    var depAssmName = dependencyRegistrar.GetType().Assembly.FullName;
                    var thisAssmName = this.GetType().Assembly.FullName;

                    if (depAssmName == thisAssmName)
                        continue;

                    bool execute = false;
                    switch (dependencyRegistrar.RegisterType)
                    {
                        case RegType.baseReg:
                        case RegType.common:
                        case RegType.handlers:
                        case RegType.edits:
                        case RegType.filters:
                        case RegType.rules:
                        
                            execute = true;
                            break;
                        default:

                            break;
                    }

                    if (!execute)
                        continue;

                    builder = new ContainerBuilder();
                                  

                    dependencyRegistrar.Register(builder, container, typeFinder, config, opts);

                    builder.Update(container);
                }
            }
            Registrations = container
                                .ComponentRegistry
                                .Registrations
                                .Select(r => r.Activator.LimitType);

            //var HandlerTypes = EngineContext
            //                      .Current
            //                      .ContainerManager
            //                      .Resolve<ITypeFinder>()
            //                      .FindClassesOfType<IHandler>()
            //                      .Where(w => typeof(IGenericHandler).IsAssignableFrom(w)
            //                             ||   typeof(IServiceHandler).IsAssignableFrom(w));

            Dups = Registrations
                         .Select(s => s)
                         //.GroupBy(g => new { g.Name,g.Assembly.FullName })
                         .GroupBy(g => new { g.Name })
                         .Where(w => w.Skip(1).Any() && 1==2)
                         .SelectMany(sm => sm);
            
            

        }

        public IEnumerable<Type> Registrations { private set; get; }
        public IEnumerable<Type> Dups { private set; get; }

        ReposCore.Infrastructure.DependencyManagement.ContainerManager IEngine.ContainerManager => throw new NotImplementedException();

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
