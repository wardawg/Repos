using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repos.DomainModel.Interface.Interfaces;
using ReposData.Custom.Types;
using ReposDomain.Rules;
using RepoUnitTest.Entities;
using RepoUnitTest.ViewModels;
using System.Web.Http.ModelBinding;
//using System.Web.Mvc;

namespace ReposDomain.Validation.Rules
{
    public class TestEntityRule
        : DomainBaseRules<TestEntity, TestViewModel>
    {
       
        //public void RunRules(IBaseEntity Entity, EntityRules Entities, ModelStateDictionary modelState)
        //{
        // //   modelState.AddModelError("", "TestEntityError");
        //}


        //public void RunRulesOnModel(IViewModel Entity, ModelStateDictionary modelState)
        //{
        //    if ( ((TestViewModel)Entity).Name == string.Empty)
        //        modelState.AddModelError("", "TestEntityError on Model");
        //}
        public TestEntityRule(IServiceHandlerFactory ServiceHandlerFactory) 
            : base(ServiceHandlerFactory)
        {
        }

        public override bool Required { get; set; } = true;

        public override bool IsBaseRule => true;

     
        public override void RunRules(IBaseEntity Entity, EntityRules Entities, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
        {
            throw new System.NotImplementedException();
        }
               
        public override void RunRulesOnModel(IViewModel Entity, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
        {
            throw new System.NotImplementedException();
        }
    }

}
