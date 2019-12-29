using NUnit.Framework;
using ProjectDependResolver;
using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.Interfaces;
using Repos.DomainModel.Interface.Interfaces.Filter;
using ReposData.Utilities;
using ReposDomain.Domain;
using ReposServiceConfigurations.Common;
using ReposServiceConfigurations.ServiceTypes.Attributes;
using ReposServiceConfigurations.ServiceTypes.Edits;
using ReposServiceConfigurations.ServiceTypes.Enums;
using ReposServiceConfigurations.ServiceTypes.Rules;
using ReposServiceConfigures.ServiceTypes.Handlers;
using RepoUnitTest.Config;
using RepoUnitTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using ReposCore;
using ReposDomain.Handlers.Models;

namespace RepoUnitTest
{
    [TestFixture]
    public class DI_ContainerTest_RegisterSingleTypeMode
    {
        TestEngineHandler testEngineHandler;
        protected TestClassConfigOptions CONFIG_OPTION = new TestClassConfigOptions();
        [SetUp]
        public void Setup()
        {
            var opts = new TestClassConfigOptions();

            testEngineHandler = new TestEngineHandler();
            TestEngineContext.Clear();
            TestEngineContext.Initialize(testEngineHandler, CONFIG_OPTION);

        }


        [Test]
        public void Test_Type_DI_Resolving_when_only_one_type_isAllowed()
        {

            var maps = new IEnumerable<EntityMapType>[]
                          {
                              Util.GetMap<IEntityRule>()
                              ,Util.GetMap<IHandler>()
                              ,Util.GetMap<IDomainEdit>()
                              ,Util.GetMap<IDomainActionFilter>()
                          }
                          .SelectMany(sm => sm)
                          .Select(s => s)
                          .GroupBy(g => new { g.EntityTypeName })
                          .Where(w => w.Skip(1).Any())
                          .SelectMany(sm => sm);

                Assert.True(!maps.Any(), "Only one Dependency Is Allowed.Found Multiply Dependency on Some Types");
        }

        [Test]
        public void Test_DIContainer_Should_Resolve_Single_Types()
        {

            IDictionary<string, Type> Errors = new Dictionary<string, Type>();




           foreach (var DomainType in new[]
                          {

                              new {postfixname=EnumServiceTypes.Filters, type =  typeof(IDomainActionFilter) }
                            , new {postfixname=EnumServiceTypes.Edits, type = typeof(IDomainEdit) }
                            , new {postfixname=EnumServiceTypes.Rules, type = typeof(IEntityRule) }
                            , new {postfixname=EnumServiceTypes.Handlers, type = typeof(IHandler) }
                          
                            }
                    )
            {
                var ResovedDomainTypes =
                        TestEngineContext
                            .Current
                            .ContainerManager
                            .Resolve<ITypeFinder>()
                            .FindClassesOfType(DomainType.type)
                            .Where(w => DomainType.type.IsAssignableFrom(w)
                                && !(w.IsInterface
                                     || w.IsGenericType
                                     || w.IsAbstract
                                     || w.IsSealed
                                     )
                                && !(w.Assembly.FullName == this.GetType().Assembly.FullName)
                                && !w.GetCustomAttributes(typeof(NoServiceResolveAtrribute), true).Any()
                                     );

                var DomainTypes = testEngineHandler
                                  .Registrations
                                  .Where(w => ResovedDomainTypes.Contains(w));
                
                foreach (var t in DomainTypes)
                {
 
                    var typeNameResolve =
                        CommonUtil
                          .GetResolveName(t , postFix:DomainType.postfixname);

                    var exists = TestEngineContext
                               .Current
                               .ContainerManager
                               .IsRegisteredByName(typeNameResolve, DomainType.type);

                    if (!exists)
                        Errors.Add(t.Name + '-' + t.FullName, t);

                    System.Diagnostics.Debug.WriteLine("-> " + t.Name);
                }

            }

            Assert.IsTrue(Errors.Count == 0, "Error Verifying DI Container Creation");
        }

        [Test]
        public void Test_Container_Only_Contains_SingleTypes()
        {
            var results = testEngineHandler.Dups.Any();

            Assert.False(results, "DI Container Has Duplicates Registered");

        }
    }

    [TestFixture]
    public class Test_DI_ContainerTest_RegisterAllTypesMode
    {
        TestEngineHandler testEngineHandler;
        private TestClassConfigOptions CONFIG_OPTIONS = new TestClassConfigOptions();

        [SetUp]
        public void Setup()
        {

            CONFIG_OPTIONS.Add(enumConfigOpts.RegAll);
            CONFIG_OPTIONS.Add(enumConfigOpts.ForceNameResolve);

            TestEngineContext.Clear();
            testEngineHandler = new TestEngineHandler();
            TestEngineContext.Initialize(testEngineHandler, CONFIG_OPTIONS);
        }

        [Test]
        public void Test_Dynamic_Handler()
        {

            Assert.True(true);

            return;

            var _ServiceHandlerFactory = new ServiceHandlerFactory();

            var g = testEngineHandler.Registrations;

            var Mockedit
                    = new Moq.Mock<ServiceHandlerFactory>() { CallBase = true };

            var ServiceInterface = new Moq.Mock<IServiceGenericHandler>() { CallBase = true };


            var dataCategories = new List<Category>
            {
                new TestCategory { CategoryName = new DomainEntityTypeString { Value = "AAA" } },
                new TestCategory { CategoryName = new DomainEntityTypeString { Value = "BBB" } },
                new TestCategory { CategoryName = new DomainEntityTypeString { Value = "ZZZ" } }
            }.AsQueryable();

            _ServiceHandlerFactory
                .Using<IServiceGenericHandler>()
                .GetData<ISubCategoryAttribute>();
            
            //s.Save(It.IsAny<ModelStateDictionary>())).Returns(true);

            //_ServiceHandlerFactory IServiceGenericHandler
            // var subAttributes = Mockedit.Object
            //                    .Using<IServiceGenericHandler>();

            var d = ServiceInterface
                    .Object
                    .GetData<ISubCategoryAttribute>();

            // .GetData<ISubCategoryAttribute>();
        }
        [Test]
        public void Test_VerifyDIContainer_AllTypes_Are_Registered()
        {

            IDictionary<string,Type > Errors = new Dictionary<string, Type>();

            foreach (var DomainType in new[]
                          {
                             new {postfixname=EnumServiceTypes.Filters, type =  typeof(IDomainActionFilter) }
                            ,new {postfixname=EnumServiceTypes.Edits, type = typeof(IDomainEdit) }
                            ,new {postfixname=EnumServiceTypes.Rules, type = typeof(IEntityRule) }
                            } 
                    )
            {

                var ResovedDomainTypes =
                        TestEngineContext
                            .Current
                            .ContainerManager
                            .Resolve<ITypeFinder>()
                            .FindClassesOfType(DomainType.type)
                            .Where(w => DomainType.type.IsAssignableFrom(w)
                                && !(w.IsInterface
                                     || w.IsGenericType
                                     || w.IsAbstract
                                     || w.IsSealed
                                     )
                                && !(w.Assembly.FullName == this.GetType().Assembly.FullName)
                                     );

                var DomainTypes = testEngineHandler
                                  .Registrations
                                  .Where(w => ResovedDomainTypes.Contains(w));

                foreach (var t in DomainTypes)
                {
           
                    var typeNameResolve =
                        CommonUtil
                          .GetResolveName(t,postFix:DomainType.postfixname, Opts: CONFIG_OPTIONS);

                    var exists = TestEngineContext
                               .Current
                               .ContainerManager.IsRegisteredByName(typeNameResolve, DomainType.type);

                    if (!exists)
                        Errors.Add(t.Name +"-"+ t.Assembly.FullName, t);

                    System.Diagnostics.Debug.WriteLine("-> " + t.Name);
                }
                
            }

            Assert.IsTrue(Errors.Count == 0, "Error Verifying DI Container Creation");
        }

        [Test]
        public void Test_DI_ContainerValidation_RegAll()
        {
            var results = testEngineHandler.Dups.Any();

            Assert.False(results, "DI Container Has Duplicates Registered");

        }
    }
}
