using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repos.DomainModel.Interface.Interfaces;
using ReposData.Custom.Types;
using ReposServiceConfigurations.ServiceTypes.Rules;
using RepoUnitTest.Entities;
using System;
using System.Web.Mvc;
using ModelStateDictionary = Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace RepoUnitTest.Rules
{
    public class TestEntityNullRule
        : IEntityRule<TestEntity>
    {
        private string rule { set; get; }
        public bool Required { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsBaseRule => throw new NotImplementedException();

        public TestEntityNullRule(){
        }
        public TestEntityNullRule(string Rule)
        {
            rule = Rule;
        }

        public void RunRules(IBaseEntity Entity, EntityRules Entities, ModelStateDictionary modelState)
        {
        }

        public void RunRulesOnModel(IViewModel Entity, ModelStateDictionary modelState)
        {
          if(!string.IsNullOrEmpty(rule))
            {
                modelState.AddModelError(key:null,errorMessage:rule);

            }
        }

      
    }
}
