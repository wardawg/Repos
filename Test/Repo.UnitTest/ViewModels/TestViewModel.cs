using Repos.DomainModel.Interface.Interfaces;
using Repos.Models;
using Repos.DomainModel.Interface.DomainViewModels;
using ReposServiceConfigurations.ServiceTypes.Rules;
using RepoUnitTest.Entities;
using System;
using System.Web.Mvc;
using ReposData.Custom.Types;
using Repos.Models.SubCategories;

namespace RepoUnitTest.ViewModels
{
    public class TestViewModel
        : ViewModel<TestEntity>
        , IDomainViewModel<TestEntity>
        , Repos.DomainModel.Interface.Interfaces.IModelRule
        , IBaseViewModelRule
        , IEntityRule


    {
        public string Name { set; get; }
        public int someInt { set; get; }
        public double someDouble { set; get; }
        public long someLong { set; get; }

        public bool IsBaseRule => true;

        bool IEntityRule.Required { get => true; set => throw new NotImplementedException(); }

        public TestViewModel()
        {

        }
        public void RunRules(IBaseEntity Entity, EntityRules Entities, ModelStateDictionary modelState)
        {

        }

        public void RunRulesOnModel(IViewModel Entity, ModelStateDictionary modelState)
        {
            var entityName = Entity.GetType().Name;
            switch (entityName)
            {
                case "SubCategoryModel":
                    var name = ((SubCategoryModel)Entity).SubCategoryName.Value.ToLower();

                    if (string.IsNullOrEmpty(name))
                        modelState.AddModelError("",string.Format("Error in {0}", entityName));

                    break;
            }
        }

        public void SetViewModelRules(IRule RuleFactory)
        {

        }

        public void ValidModelRules(IRule RuleFactory, ModelStateDictionary modelstate)
        {
            if (Name != "Some Value")
                throw new Exception("Should Not Throw Exception");
        }
    }
}
