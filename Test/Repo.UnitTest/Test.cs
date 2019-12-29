using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Repos.Common.Edits.SubCategories;
using Repos.DomainModel.Interface.Atrributes.DynamicAttributes;
using Repos.DomainModel.Interface.Attributes.DynamicAttributes;
using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.DomainViewModels;
using Repos.DomainModel.Interface.Filters;
using Repos.DomainModel.Interface.Interfaces;
using Repos.DomainModel.Interface.Interfaces.Filter;
using Repos.Models.SubCategories;
using ReposCore.Caching;
using ReposCore.Extensions;
using ReposCore.FunctionInterfaces;
using ReposCore.Infrastructure;
using ReposData.Custom.Types;
using ReposData.Repository;
using ReposDomain.Domain;
using ReposDomain.Filters;
using ReposDomain.Filters.Extensions;
using RepoServices.CustomerServices;
using ReposServiceConfiguration.ServiceTypes.Base;
using ReposServiceConfigurations.Common;
using ReposServiceConfigurations.Extensions;
using ReposServiceConfigurations.ServiceTypes.Base;
using ReposServiceConfigurations.ServiceTypes.Rules;
using ReposServices.ClientsServices;
using ReposServices.SubCategoriesServices;
using RepoUnitTest.Context;
using RepoUnitTest.Controllers;
using RepoUnitTest.Edits;
using RepoUnitTest.Entities;
using RepoUnitTest.Factories;
using RepoUnitTest.Services;
using RepoUnitTest.Services.Handler;
using RepoUnitTest.Utilities;
using RepoUnitTest.ViewModels;
using ServiceRules.Factory;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web.Http.ModelBinding;
//using System.Web.Mvc;
using EditReposFilters = ReposDomain.Filters.ReposFilters;
using Microsoft.AspNet.Mvc;
using WebApplicationCore.Controllers;
namespace RepoUnitTest
{

    public class TestSubCategoryItem : SubCategoryItem
    {
        public new int Id { set; get; }
    }

    public class TestCategory : Category
    {
        public new int Id { set; get; }
    }

    public class TestSubCategory : SubCategory
    {
        public new int Id { set; get; }

        public TestSubCategory()
        {
            dynamic attr = new ExpandoObject();
            attr.propList = new List<PropListKeyPair>();

           
            attr.propList.Add(new PropListKeyPair() { Key = "1", Value = "Test1" });
            attr.propList.Add(new PropListKeyPair() { Key = "2", Value = "Test2" });
            attr.propList.Add(new PropListKeyPair() { Key = "3", Value = "Test3" });

            this.CategoryTypeId =
            new DomainEntityTypeInt
            {
                Value = int.MaxValue
               ,Attributes= attr
            };
        }

        public class TestCustomer : Customer
        {
            public new int Id { set; get; }
        }

        //}

        [TestFixture]
        class BaseTests
        {

            /*
            ICategoriesService CategoriesService
                                     , ISubCategoriesService SubCategoriesService
                                     , ISubCategoryTypesService SubCategoryTypeService
                                     , ISubCategoryItemsService SubCategoryItemsService
                                     //                                   , ICacheManager CacheManager
                                     , IServiceHandlerFactory ServiceHandlerFactory
                                     , IRule RuleFactory
                                     , IFilterFactory FilterFactory
                                     , ICommonInfo   CommonInfo

 *                 */

                //
            // rules 
            Moq.Mock<IRule> G_IRule;
            // filter
            Moq.Mock<IFilterFactory> G_mockFilterFactory;
            // Common
            CommonInfo G_CommonInfo; 

            //Cache
            ICacheManager _CacheManager;

            // Context
            Moq.Mock<ReposContext> _Context;

            // UOW

            TestUnitOfWork G_UnitOfWork;

            //    ,IUnitOfWorkManager UnitOfWorkManger

            ///repositories
            Moq.Mock<IRepository<SubCategory>> G_mockSubCategoryRepository;
            Moq.Mock<IRepository<Category>> G_mockCategoryRepository;
            Moq.Mock<IRepository<SubCategoryItem>> G_mockSubCategoryItemRepository;
            Moq.Mock<IRepository<SubCategoryType>> G_mockSubCategoryTypeRepository;

            // services
            Moq.Mock<ICategoriesService> G_mockCategoriesService;
            Moq.Mock<ISubCategoriesService> G_mockSubCategoriesService;
            Moq.Mock<ISubCategoryItemsService> G_mockSubCategoryItemsService;
            Moq.Mock<ISubCategoryTypesService> G_mockSubCategoryTypesService;
            Moq.Mock<ISubCategoryClassItemsService> G_mockSubCategoryClassItemService;
            Moq.Mock<IServiceHandlerFactory> G_mockServiceHandlerFactory;
            Moq.Mock<IClientsService> G_mockClientsServices;

            // UOW

            Moq.Mock<IUnitOfWork> G_mockUnitOfWork;

            
            #region Setup
            [SetUp]
            public void Setup()
            {

                ConfigTestEnv.Init();

                AutoMapperConfiguration.Init<IBaseEntity, IDomainViewModel,IDomainEntityType>();
                //    DomainEntityTpe


                G_UnitOfWork = new TestUnitOfWork();

                _CacheManager = EngineContext.Current.Resolve<ICacheManager>();


                G_IRule = new Moq.Mock<IRule>() { CallBase = true };

                G_CommonInfo  = new CommonInfo();

                G_mockFilterFactory = new Moq.Mock<IFilterFactory>() { CallBase = true };

                


                //Initialize Fakes

                // Context 
                _Context = new Moq.Mock<ReposContext>() { CallBase = true };
                //Repos
                G_mockSubCategoryRepository = new Moq.Mock<IRepository<SubCategory>>() { CallBase = true };

                //Services
                G_mockServiceHandlerFactory = new Moq.Mock<IServiceHandlerFactory>() { CallBase = true };

                G_mockSubCategoriesService = new Moq.Mock<ISubCategoriesService>() { CallBase = true };
                G_mockSubCategoryTypesService = new Moq.Mock<ISubCategoryTypesService>() { CallBase = true };
                G_mockCategoriesService = new Moq.Mock<ICategoriesService>() { CallBase = true };
                G_mockSubCategoryItemsService = new Moq.Mock<ISubCategoryItemsService>() { CallBase = true };
                G_mockSubCategoryClassItemService = new Moq.Mock<ISubCategoryClassItemsService> { CallBase = true };

                // IQueryable setup

                //Category category = null;
                //SubCategory subCategory = null;
                //BaseEntity baseEntity = null;


                //IQueryable<BaseEntity> BaseEntityQueryable
                //            = new[] { baseEntity, }.Where(query => query != null).AsQueryable();

                var dataCategories = new List<Category>
            {
                new TestCategory { CategoryName = new DomainEntityTypeString { Value = "AAA" } },
                new TestCategory { CategoryName = new DomainEntityTypeString { Value = "BBB" } },
                new TestCategory { CategoryName = new DomainEntityTypeString { Value = "ZZZ" } },
            }.AsQueryable();


                //Mock Setups

                _Context.Setup(c => c.SaveChanges()).Returns(1);
                //var Set = _Context.Object.Set<SubCategory>();

                //   var DB = new TestDbSet<SubCategory>();
                //    _Context.Setup(m => m.Set<SubCategory>()).Returns(DB);


                // services
              
                G_mockSubCategoriesService.Setup(s => s.Verify(It.IsAny<ModelStateDictionary>())).Returns(Result.Success);
              

                // Repos
                
           
                //IEnumerable<IBaseEntity> Ent = new List<BaseEntity>();
                G_mockSubCategoryRepository.Setup(s => s.ModifiedEntities).Returns(It.IsAny<EntityRules>());
                //G_mockSubCategoryRepository
                //    .Setup(s => s.Verify(It.IsAny<ServiceRuleFunc<bool>>()
                //                        , It.IsAny<ModelStateDictionary>()
                //                        , It.IsAny<object>())).Returns(Result.Success);

            }

            #endregion


            [Test]
            public void Test_Repository_Save_Executed()
            {
                var MockRepos = new Mock<IRepository<TestEntity>>();
                //MockRepos.Setup(s => s.Verify(It.IsAny<ServiceRuleFunc<bool>>()
                //                            , It.IsAny<ModelStateDictionary>()
                //                            , It.IsAny<object>())).Returns(Result.Success);

                var MockService
                    = new Mock<TestServices<TestEntity>>(
                        MockRepos.Object
                        , null
                        , null)
                    { CallBase = true };



                MockService.Object.Verify(It.IsAny<ModelStateDictionary>());

                MockService.Verify(s => s.Verify(It.IsAny<ServiceRuleFunc<bool>>()
                                            , It.IsAny<ModelStateDictionary>()
                                            , It.IsAny<object>()), Times.Once , "Save Failed With Arguments");

              
            }



            [Test]
            public void Test_Generic_Rules_Are_Valid()
            {
                var isValid = Test_Rules("TestEntity");

                Assert.IsTrue(isValid, "Call To Save Should Be valid");
            }

            [Test]
            public void Test_Generic_Rules_are_Invalid()
            {
                var isNotValid = Test_Rules("TestEntityErrorRule");

                Assert.IsTrue(isNotValid, "Call To Save Should Be Invalid");


            }

            public bool Test_Rules(string RuleName)
            {
                var ruleEntity = new TestEntityError();

                var context = new ReposContext();

                var uow = new Mock<IUnitOfWork>();


                ModelStateDictionary modelState = new ModelStateDictionary();
                var MockRepos = new Mock<IRepository<TestEntityError>>();


                
                MockRepos.Setup(s => s.Add(new Moq.Mock<TestEntityError>().Object));

                var Ent = new EntityRules(null);

                switch (RuleName)
                {
                    case "TestEntity":
                        Ent.Rules.Add("TestEntity", new TestEntity());
                        break;
                    case "TestEntityError":
                        Ent.Rules.Add("TestEntityError", new TestEntityError());
                        break;
                }

                MockRepos.Setup(s => s.Add(ruleEntity));
                MockRepos.Setup(s => s.ModifiedEntities).Returns(Ent);

                var MockRules = new Moq.Mock<TestRulesFactory>() { CallBase = true };
                
                var _service = new Moq.Mock<TestServicesError>(
                     MockRepos.Object
                    , new Moq.Mock<TestDomainEdit>().Object
                    , MockRules.Object
                    )
                { CallBase = true };

                _service.Object.Add(ruleEntity);
                _service.Object.Verify(modelState);

                var res = modelState.IsValid;
                            
                return res;
            }
                       


            [Test]
            public void Test_Edits_Defaults_Should_Execute_From_Service()
            {

                var Mockedit
                    = new Moq.Mock<TestDomainEdit>() { CallBase = true };

                var ret =
                    Mockedit
                      .Setup(s =>

                                s.CreateEdit<TestEntity>()
                                 .SetEntityDefaults(It.IsAny<TestEntity>()));

                var MockService = new Moq.Mock<TestServices<TestEntity>>(
                    new Mock<IRepository<TestEntity>>().Object
                   , Mockedit.Object
                   , new Moq.Mock<IRule>().Object
                   )
                { CallBase = true };


                MockService.Object.CreateServiceEntity();

                Mockedit.Verify(mock =>
                    mock.CreateEdit<TestEntity>()
                        .SetEntityDefaults(It.IsAny<TestEntity>()), Times.Once);
            }

            [Test]
            public void Test_Rules_Should_Not_Run_When_Parent_Rule_Is_Disbled()
            {
                rules_should(false);
            }

            [Test]
            public void Test_Rules_Should_Run_When_Parent_Rule_Is_Enabled()
            {
                rules_should(true);
            }

            private void rules_should(bool choice)
            {

                var MockModelState = new Moq.Mock<ModelStateDictionary>();
                var MockEdit = new Moq.Mock<TestDomainEdit>();
                var MockRules = new Moq.Mock<IRule>();
                //_Context.Object
                var MockRepos = new Mock<IRepository<TestEntity>>();

                var Ent = new EntityRules(null);
                Ent.Rules.Add("TestEntity", new TestEntity());
                MockRepos.Setup(s => s.ModifiedEntities).Returns(Ent);
                MockRepos.Setup(s => s.Add(It.IsAny<TestEntity>()));
                //MockRepos.Setup(s =>
                //  s.RunRules(It.IsAny<ServiceRuleFunc<bool>>()
                //           , It.IsAny<ModelStateDictionary>()
                //           , It.IsAny<object>())).Returns(true);


                var _service = new Moq.Mock<TestServices<TestEntity>>(
                      MockRepos.Object
                    , new Moq.Mock<TestDomainEdit>().Object
                    , MockRules.Object
                    )
                { CallBase = true };

                _service.Setup(s =>
                 s.RunRules(It.IsAny<ServiceRuleFunc<bool>>()
                          , It.IsAny<object>()
                          , It.IsAny<object>())).Returns(true);


                var te = new TestEntity();
                te.RulesEnabled = choice;
                _service.Object.Add(te);
                _service.Object.Verify(MockModelState.Object);


                if (choice)
                {
                    _service.Verify(mock =>
                        mock.RunRules(It.IsAny<ServiceRuleFunc<bool>>()
                                    , It.IsAny<ModelStateDictionary>()
                                    , It.IsAny<object>()), Times.Once, "Rules Should Run");
                }
                else
                {
                    _service.Verify(mock =>
                        mock.RunRules(It.IsAny<ServiceRuleFunc<bool>>()
                                    , It.IsAny<ModelStateDictionary>()
                                    , It.IsAny<object>()), Times.Never, "Rules Should Not Run");
                }

            }

            [Test]
            public void Test_Rules_Are_Executed_From_Service()
            {
                ModelStateDictionary modelState = new ModelStateDictionary();
                var MockRepos = new Mock<IRepository<TestEntity>>();
                MockRepos.Setup(s => s.Add(It.IsAny<TestEntity>()));
                //MockRepos.Setup(s =>
                //  s.RunRules(It.IsAny<ServiceRuleFunc<bool>>()
                //           , It.IsAny<ModelStateDictionary>()
                //           , It.IsAny<object>())).Returns(true);

                var Mockedit
                  = new Moq.Mock<TestDomainEdit>() { CallBase = true };

                var MockRulesFactory = new Moq.Mock<IDomainRule>();

                var _service = new Moq.Mock<TestServices<TestEntity>>(
                      MockRepos.Object
                    , Mockedit.Object
                    , MockRulesFactory.Object
                    )
                { CallBase = true };


                _service.Setup(s=> s.RunRules(It.IsAny<ServiceRuleFunc<bool>>()
                         , It.IsAny<ModelStateDictionary>()
                         , It.IsAny<object>())).Returns(true);


                var tt = new TestEntity();

                _service.Object.Add(tt);

                _service.Object.Verify(modelState);

                _service.Verify(mock =>
                    mock.RunRules(It.IsAny<ServiceRuleFunc<bool>>()
                                , It.IsAny<ModelStateDictionary>()
                                , It.IsAny<object>()), Times.Once, "Rules Didn't Run");

            }

            //[Test]
            public void rules_are_executed_with_not_vaild_rules()
            {

                ModelStateDictionary modelState = new ModelStateDictionary();

                var _edit = new Moq.Mock<SubCategoryEdits>(_Context.Object);
                var x_scRepos = new Mock<EfRepository<SubCategory>>(_Context.Object) { CallBase = true };
                x_scRepos.Setup(s => s.Add(It.IsAny<SubCategory>()));
                x_scRepos.Setup(s => s.ModifiedEntities).Returns(It.IsAny<EntityRules>());
                //x_scRepos.Setup(s =>
                //  s.RunRules(It.IsAny<ServiceRuleFunc<bool>>(), It.IsAny<ModelStateDictionary>(), It.IsAny<object>())).Returns(true);

                var subCategoryEntity = new TestSubCategory
                {
                    Id = 1
                                                              ,
                    SubCategoryName = new DomainEntityTypeString { Value = "Default" }
                };

                subCategoryEntity.SubCategoryName.Value = "dd";


                var _service = new Moq.Mock<SubCategoriesService>();
                var testRulesFactory = new TestRulesFactory();
                _service = new Moq.Mock<SubCategoriesService>(x_scRepos.Object
                    , _edit.Object, testRulesFactory)
                { CallBase = true };

                _service.Object.Add(subCategoryEntity);

               
                _service.Object.Verify(modelState);
                //SetEntitiesDefaults(It.IsAny<SubCategory>()
                _service.Verify(mock => _service.Object.RunRules(It.IsAny<ServiceRuleFunc<bool>>(), It.IsAny<ModelStateDictionary>(), It.IsAny<object>()), Times.Once);
                //  SubCategoryRules

                 //  MockSubCategoryEdits.Verify(mock => mock.SetEntitiesDefaults(It.IsAny<SubCategory>()), Times.Once);

               //  Assert.IsTrue(modelState.Count == 1, "Model Validation Rule didn't Failed.");
            }
            
            //[Test]
            public void edits_are_executed_()
            {
                Moq.Mock<SubCategoryEdits> _edit;

                Moq.Mock<SubCategoriesService> _service;
                /*
                 * public SubCategoriesService(IRepository<SubCategory> subCategoryRepository
                                        , IServiceEntityEdit<SubCategory> Edits
                                        )
                                        */

                var context = new ReposContext("ReposContext");


                _edit = new Moq.Mock<SubCategoryEdits>(_Context.Object);

                var scRepos = new EfRepository<SubCategory>(G_mockUnitOfWork.Object);

                //var _scRepos = new Mock<EfRepository<SubCategory>>(context); //.Object) { CallBase = true };

                var sc = new TestSubCategory
                {
                    Id = 1,
                    SubCategoryName = new DomainEntityTypeString { Value = "Default" }
                };

            var dataCategories = new List<Category>
            {
                new TestCategory { CategoryName = new DomainEntityTypeString { Value = "AAA" } },
                new TestCategory { CategoryName = new DomainEntityTypeString { Value = "BBB" } },
                new TestCategory { CategoryName = new DomainEntityTypeString { Value = "ZZZ" } }
            }.AsQueryable();

                var mockSet = new Mock<DbSet<SubCategory>>() { CallBase = true };

                var DB = new TestDbSet<SubCategory>(); //                   DbSet<SubCategory>();

                mockSet.As<IQueryable<SubCategory>>().Setup(m => m.Provider).Returns(dataCategories.Provider);
                mockSet.As<IQueryable<SubCategory>>().Setup(m => m.Expression).Returns(dataCategories.Expression);
                mockSet.As<IQueryable<SubCategory>>().Setup(m => m.ElementType).Returns(dataCategories.ElementType);
                //   mockSet.As<IQueryable<SubCategory>>().Setup(m => m.GetEnumerator()).Returns(o => dataCategories.GetEnumerator());


                //_Context.Setup(m => m.Set<SubCategory>()).Returns(DB);

                var MockDbContext = EntityFrameworkMockHelper.GetMockContext<IDbContext>();
                MockDbContext.CallBase = true;


                MockDbContext.Setup(m => m.Set<SubCategory>()).Returns(DB);

                var _scRepos = new Mock<IRepository<SubCategory>>() { CallBase = true };

                // var mockSet = new Mock<DbSet<SubCategory>>() { CallBase = true };

                var x_scRepos = new Mock<EfRepository<SubCategory>>(G_mockUnitOfWork.Object) { CallBase = true };

                x_scRepos.Setup(s => s.Add(It.IsAny<SubCategory>()));
                x_scRepos.Setup(s => s.ModifiedEntities).Returns(It.IsAny<EntityRules>());


                var scReposx = new EfRepository<SubCategory>(G_mockUnitOfWork.Object);

                var testRulesFactory = new TestRulesFactory();

                _service = new Moq.Mock<SubCategoriesService>(x_scRepos.Object //_mockSubCategoryRepository.Object
                    , _edit.Object, testRulesFactory)
                { CallBase = true };


                var cat = EntitiesUtil.CreateEntity<SubCategory>();


                _edit.Setup(s => s.SetEntitiesDefaults(cat));

                var Model = new SubCategoryModel
                {
                    SubCategoryName
                        = new DomainEntityTypeString { Value = "Defaultx", Attributes = null }

                };

                //   _service.Object.CreateServiceEntity();

                ModelStateDictionary modelState = new ModelStateDictionary();

                //  _service.Object.Save();

                var subCategoryEntity = new TestSubCategory
                {
                    Id = 1
                                                            ,
                    SubCategoryName = new DomainEntityTypeString { Value = "Default" }
                };



                _service.Object.Add(subCategoryEntity);

                _service.Object.Verify(modelState);

                // _edit.Object.SetEntitiesDefaults(cat);

                //   _edit.Verify(s => s.SetEntitiesDefaults(cat), Times.Once);


            }



            /// <summary>
            /// 
            /// </summary>
            [Test]
            public void Test_Enitity_Mapping_IsValid()
            {

                //TestDbContext
                //ReposContext
                var context = new ReposContext("ReposContext");

                // var uow = new UnitOfWork(context);

                var uow = new Moq.Mock<UnitOfWork>(context) { CallBase = false };


//                var rep = new Moq.Mock<EfRepository<TestEntity>>( ) { CallBase = false };
          
                var _service = new TestServices<TestEntity>(
                    null, null, null);

                var _handler = new TestServiceHandlerFactory(_Context.Object);

                var subAttributes = _handler
                                        .Using<IServiceGenericHandler>()
                                        .GetData<ITestReposAttribute>()
                                        .OfType<TestReposAttribute>()
                                        .Any();

                Assert.IsNotNull(subAttributes, "Helper Handler should not return null");

                                //.ToList();
            }

            /// <summary>
            /// 
            /// </summary>
            [Test]
            public void Test_Validate_Generic_Handler()
            {

                TestServiceHandlerFactory
                    _ServiceHandlerFactory = new TestServiceHandlerFactory();

                var isTrue = _ServiceHandlerFactory
                                    .Using<IServiceGenericHandler>()
                                    .GetData<ITestReposAttribute>()
                                    .OfType<TestReposAttribute>().Any();

                Assert.IsTrue(isTrue,"GenericHandler Is Not Valid");

            }

            [Test]
            public void Test_AutoMapper_Is_Valid()
            {

                var map = AutoMapperConfiguration.Mapper;
    
                var MockRepos = new Moq.Mock<IBaseService<TestEntity>>();


                // var MockSubCategory = new Moq.Mock<model.GetType() > ();
                var sc = new TestEntity()
                {
                    Name = new DomainEntityTypeString { Value = "mapping" }
                     ,
                    ComplexInt = new DomainEntityTypeInt { Value = int.MaxValue }
                     ,
                    someInt = int.MinValue
                    ,Id = 1001
                };

            //sc.CategoryId.Value = 1;
            //sc.CategoryTypeId.Value = 2;
            //sc.SubCategoryName.Value = "Mapped";


            MockRepos.Setup(s => s.GetById(It.IsAny<object>())).Returns(sc);
                             
            //TestViewModel Viewmodel = MockRepos.Object.GetById(It.IsAny<object>()).ToModel();
                // modify Id
                //Viewmodel.Id = 1;
               

             //   sc = Viewmodel.ToEntity();

         //   Assert.AreEqual(sc.Id, Viewmodel.Id);
         //   Assert.AreEqual(sc.Name.Value
                            //, Viewmodel.Name);
          //  Assert.AreEqual(sc.someInt
         //                   , Viewmodel.someInt);
            }

            [Test]
            public void Test_Should_Throw_Validation_Error()
            {
                Test_Vaildator_Error("", false);

            }

            [Test]
            public void Test_Should_Not_Throw_Validation_Error()
            {
                Test_Vaildator_Error("Some Value", true);
            }

            public void Test_Vaildator_Error(string FieldValue, bool trg)
            {

                var _ServiceHandlerFactory = new TestServiceHandlerFactory();
                var _Filter = new TestFilterFactory();
                var _testRulesFactory = new TestRulesFactory();
                var _common = new CommonInfo();

                /*
                 * 
                 * (IServiceHandlerFactory ServiceHandlerFactory  
                            , IFilterFactory FilterFactory
                            , IRule RulesFactor
                            , ICommonInfo CommonInfo) 

    */


                var testController =
                      new TestController(_ServiceHandlerFactory
                                         , _Filter
                                         , _testRulesFactory
                                         ,_common
                                        );

                SetWebControllerInstance.Initialize(testController);

                                var Model = default(IBaseViewModelRule);

                Model = new TestViewModel
                {
                    Name = FieldValue
                };

                if (FieldValue == string.Empty)
                    Model = new TestErrorViewModel
                    {
                        Name = FieldValue
                    };

                testController.Validate(Model);


               
                var isTrue = testController.ModelState
                            .SelectMany(c => c.Value.Errors)
                            .Any();

                Assert.AreNotSame(isTrue.ToString(), trg.ToString(), "Validation Test Failed");


            }
            private enum EnumTest
            {
                 None
               , TestFilter
               , TestSubCategoryFilter
            }

            //[Test]
            public void Test_Apply_Attribute_Filter_IsValid()
            {
                Assert.False(1 == 1, "Test is Broken");

                var sc = new TestSubCategory();

                FilterParms filterParms = default(FilterParms);
                filterParms.Factory = new TestFilterFactory();
                filterParms.FilterEnum = EnumTest.TestSubCategoryFilter;

                //  var dynfilter = 3;

                filterParms.ParmInputs = new Dictionary<string, object>
                {
                    {"Filter" ,sc.CategoryTypeId}
                };

                sc.ApplyFilter(filterParms);
                var bres = sc.CategoryTypeId.HasAttributes(EnumAttributes.filter);

                Assert.IsTrue(bres, "Cannot Find Attributes Filter");
                
            }


            [Test]
            public void Test_Apply_Filter_V2()
            {
                var factory = new FilterFactory();
                var Entity = new TestEntity();

                factory
                    .Using<IFilterKeyPair>(EditReposFilters.CatNCatTypeDDLFilter, new DefaultClientInfo())
                    .SetValue(Entity.ComplexInt);
        }

            [Test]
            public void Test_Apply_Filter_V1()
            {


                FilterParms filterParms = default(FilterParms);
                filterParms = default(FilterParms);
                filterParms.Factory = new TestFilterFactory();
                filterParms.FilterEnum = EnumTest.TestFilter;

                var expectedResult = 3;

                filterParms.ParmInputs = new Dictionary<string, object>
            {
                {"Arg" ,expectedResult}
            };

                var result = expectedResult.ApplyFilter(filterParms);

                Assert.AreEqual(expectedResult, result, string.Format("Filter, Expected{0} Got {1}", expectedResult, result));

            }


            [Test]
            public void Test_SubCategoryControl_Create_Is_Not_Valid()
            {


                var dataSubCategories = new List<SubCategory>
            {
                new TestSubCategory { Id=1, SubCategoryName =  new DomainEntityTypeString { Value = "ABC" }},
                new TestSubCategory { Id=2, SubCategoryName =  new DomainEntityTypeString { Value = "ZZZ" }},
                new TestSubCategory { Id=3, SubCategoryName =  new DomainEntityTypeString { Value = "MMM" }},
            }.AsQueryable();

                G_mockSubCategoriesService.Setup(s => s.GetAll()).Returns(dataSubCategories);

                //var sc = new Moq.Mock<SubCategory>();

                var sc = new TestSubCategory();

                G_mockSubCategoriesService.Setup(s => s.CreateServiceEntity()).Returns(sc);


                var si = new Moq.Mock<SubCategoryClassItem>();
                G_mockSubCategoryClassItemService.Setup(s => s.CreateServiceEntity()).Returns(si.Object);


                

                var _ServiceHandlerFactory = new TestServiceHandlerFactory();

                var _Filter = new TestFilterFactory();

                var _rule = new TestRulesFactory();

                var common = new CommonInfo();

                var controller =
                    new SubCategoryController(G_mockCategoriesService.Object
                                            , G_mockSubCategoriesService.Object
                                            , G_mockSubCategoryTypesService.Object
                                            , G_mockSubCategoryItemsService.Object
                                            , _ServiceHandlerFactory
                                            , G_mockSubCategoryClassItemService.Object
                                            , _Filter
                                            , _rule
                                            , common
                                            , G_UnitOfWork
                                            );

                SetWebControllerInstance.Initialize(controller);
                

              var res =  controller.GetAvailableCategory(1, 1);

                dynamic attr = new ExpandoObject();
              //  attr.propList = new List<PropListKeyPair>();
              //  attr.Filter = new List<FilterKeyPair>();

                var Model = new SubCategoryModel
                {
                    SubCategoryName
                       = new DomainEntityTypeString { Value = string.Empty, Attributes = null }
                  ,
                    CategoryId =
                    new DomainEntityTypeInt
                    {
                        Value = int.MaxValue
                        ,Attributes = attr
                    }
                  ,CategoryTypeId = new DomainEntityTypeInt { Value = int.MaxValue }
                };

                controller.Create(Model);

                var isTrue = controller.ModelState
                         .SelectMany(c => c.Value.Errors)
                         .Any(a => a.ErrorMessage.Contains("SubCategoryName"));


                Assert.IsTrue(!isTrue, "Failed to throw exception.");

            }

           // [Test]
            public void Test_Ron()
            {
                //Arrange
                Mock<IServiceGenericHandler> mockContainer = new Mock<IServiceGenericHandler>();

                var ta = new List<TestReposAttribute>()
{
                    new Mock<TestReposAttribute>().Object
               ,new Mock<TestReposAttribute>().Object
            }.AsQueryable();


                var sc = new TestSubCategory();

                G_mockSubCategoriesService.Setup(s => s.CreateServiceEntity(CreateEntityOptions.EntityEdit)).Returns(sc);


                var si = new Moq.Mock<SubCategory>();
                G_mockSubCategoriesService.Setup(s => s.CreateServiceEntity()).Returns(si.Object);

                var client = new Moq.Mock<Client>();
                G_mockClientsServices.Setup(s => s.CreateServiceEntity()).Returns(client.Object);


                var testController =
                      new SubCategoryWebController(G_mockCategoriesService.Object
                                                   , G_mockSubCategoriesService.Object
                                                   , G_mockSubCategoryTypesService.Object
                                                   //, new TestServiceHandlerFactory()        
                                                   , G_mockSubCategoryItemsService.Object
                                                   //, new TestServiceHandlerFactory()
                                                   ,G_mockClientsServices.Object
                                                 //  , null
                                                   
                                                  , G_mockServiceHandlerFactory.Object
                                                 // ,  G_mockFilterFactory.Object
                                                   , G_IRule.Object
                                                  , G_mockFilterFactory.Object
                                                   , G_CommonInfo
                                                   ,  G_UnitOfWork
                                                                                                        
                                                    );

                SetWebControllerInstance.Initialize(testController);
                var results = testController.GetAvailableCategory();

                var context3 = results.Content;

                //foreach(var c in ((dynamic)results.Content).Value)
                //{
                //    System.Diagnostics.Debug.WriteLine("");
                //}

                var t = context3;

                if (typeof(IEnumerable).IsAssignableFrom(((dynamic)results.Content).Value.GetType()))
                {
                    //foreach(var c in ((dynamic)results.Content).Value)
                    //{
                    //    System.Diagnostics.Debug.WriteLine("");
                    //}
                }
                else
                {

                }

             ///   var c = typeof(IEnumerable).IsAssignableFrom(((dynamic)results.Content).Value);

                // typeof(IEnumerable).IsAssignableFrom(((dynamic)results.Content).Value.GetType())


                // mockContainer.Setup(s => s.GetData<ITestReposAttribute>()).Returns(ta);


                var f = mockContainer.Object.GetData<ITestReposAttribute>();



                var context = new ReposContext("ReposContext");

                var uow = new UnitOfWork(context);

                var rep = new EfRepository<TestEntity>();

                var _service = new TestServices<TestEntity>(
                    rep, null, null);

                var _handler = new TestServiceHandlerFactory(context);

                var subAttributes = _handler
                                    .Using<IServiceGenericHandler>()
                                    .GetData<ITestReposAttribute>()
                                    .OfType<TestReposAttribute>()
                                    .Any();


            //  CustomerViewModel viewModel = new CustomerViewModel(mockView.Object, mockContainer.Object);
             //   viewModel.CustomersRepository = new CustomersRepository();
             //   viewModel.Customer = new Mock<Customer>().Object;

                //Act
               // viewModel.Save();

                //Assert
              //  Assert.IsTrue(viewModel.CustomersRepository.Count == 1);
            }



            //public void Test_Webapi_Parser_Attribute_IsInValid()
            //{

            //    string json3 = @"
            //                    {
            //                    'CategoryId':{'value':'2'}
            //                    ,'CategoryTypeId':'2'
            //                    ,'subCategoryName':'Create Test'
            //                    ,'subCategoryTypeName':'Create Test234'
            //                    }
            //                  ";

            //    var json = JObject.Parse(json3);
                
            //    test_webapi_parser<SubCategoryViewModel>(json, false);

            //}

            // [Test]
            //public void test_webapi_parser_isValid()
            //{

            // string json3= @"
            //                    {
            //                    'CategoryId':{'value':'2'}
            //                    ,'CategoryTypeId':{'value':'2'}
            //                    ,'subCategoryName':{'value':'Create Test'} 
            //                    ,'subCategoryTypeName':'Create Test234'
            //                    }
            //                  ";
                        

            //    var json = JObject.Parse(json3);

            
            //    dynamic json4 = new JObject();
            //    json4.CategoryId = "2";
            //   // json4.CategoryId.Attributes = new JArray() as dynamic;
            //    json4.CategoryTypeId = "2";
            //    json4.subCategoryName = "Create Test";
            //    json4.subCategoryTypeName = "Create Test234";
            //    //json4.err = "error";

            //    test_webapi_parser<SubCategoryViewModel>(json, false);
            //}

          //  [Test]
            //public void test_webapi_parser_isInValid()
            //{
            //    dynamic json = new JObject();
            //    json.CategoryId = "2";
            //    json.CategoryTypeId = "2";
            //    json.subCategoryName = "Create Test";
            //    json.xsubCategoryTypeName = "Create Test234";

            //    test_webapi_parser<SubCategoryViewModel>(json,true);
            //}


            public void test_webapi_parser<T>(JObject json,bool bBoolean)
                where T : class, IDomainViewModel
            {
                var _ServiceHandlerFactory = new TestServiceHandlerFactory();
                var _Filter = new TestFilterFactory();
                var _testRulesFactory = new TestRulesFactory();
                var _common = new CommonInfo();

                

                var testController =
                      new TestWebController(_ServiceHandlerFactory
                                            , _testRulesFactory
                                            ,_Filter
                                            ,_common
                                        );

                SetWebControllerInstance.Initialize(testController);
                               

                var res = testController.TestJsonParsing<T>(json);

                Assert.AreEqual(bBoolean,res, "webapi parser failed");

            }


        }

    }
}
