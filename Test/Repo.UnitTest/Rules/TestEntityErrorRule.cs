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
    public class TestEntityErrorRule
        : IEntityRule<TestEntityError>
    {
        public bool Required { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsBaseRule => throw new NotImplementedException();

        public void RunRules(IBaseEntity Entity, EntityRules Entities, ModelStateDictionary modelState)
        {
            modelState.AddModelError("", "TestEntityErrorRule");
        }


        public void RunRulesOnModel(IViewModel Entity, ModelStateDictionary modelState)
        {
            modelState.AddModelError("", "TestEntityErrorRule");
        }

    }
   
}
