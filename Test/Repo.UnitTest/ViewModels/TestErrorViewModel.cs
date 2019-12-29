using Repos.DomainModel.Interface.Interfaces;
using Repos.Models;
using Repos.DomainModel.Interface.DomainViewModels;
using ReposServiceConfigurations.ServiceTypes.Rules;
using RepoUnitTest.Entities;
using System;
using System.Web.Mvc;

namespace RepoUnitTest.ViewModels
{
    public class TestErrorViewModel
         : ViewModel<TestEntityError>
        , IDomainViewModel<TestEntityError>
        , Repos.DomainModel.Interface.Interfaces.IModelRule
        , IBaseViewModelRule
    {
        public string Name { set; get; }
        public int someInt { set; get; }
        public double someDouble { set; get; }
        public long someLong { set; get; }

        public void SetViewModelRules(IRule RuleFactory)
        {
            throw new NotImplementedException();
        }

        public void ValidModelRules(IRule RuleFactory, ModelStateDictionary modelstate)
        {
            if ( String.IsNullOrEmpty(Name))
                modelstate.AddModelError("", "Validation Error");
        }
    }
}
