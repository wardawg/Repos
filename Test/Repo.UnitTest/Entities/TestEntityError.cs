using Repos.DomainModel.Interface.Interfaces;
using ReposData.Custom.Types;
using ReposServiceConfigurations.ServiceTypes.Rules;
using System;
using ModelStateDictionary = Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace RepoUnitTest.Entities
{
    public class TestEntityError
        : BaseEntity<TestEntityError>, IBaseEntity 
        , IViewModel
        , IEntityRule
    {
        public string Name { set; get; }
        public int someInt { set; get; }
        public double someDouble { set; get; }
        public long   someLong   { set; get; }

       
        public bool Required { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsBaseRule => throw new NotImplementedException();

        public void RunRules(IBaseEntity Entity, EntityRules Entities, ModelStateDictionary modelState)
        {
            modelState.AddModelError("", "TestEntityError");
        }

      
        public void RunRulesOnModel(IViewModel Entity, ModelStateDictionary modelState)
        {
            modelState.AddModelError("", "TestEntityError");
        }

       
    }
}