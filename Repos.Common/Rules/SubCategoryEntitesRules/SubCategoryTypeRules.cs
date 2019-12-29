using System;
using System.Web.Mvc;
using Repos.DomainModel.Interface.DomainViewModels;
using Repos.DomainModel.Interface.Interfaces;
using ReposCore.Custom.Types;
using ReposDomain.Domain;
using ReposDomain.Rules;

namespace Repos.Common.Rules.SubCategoryEntitesRules
{
    public class SubCategoryTypeRules
        : DomainBaseRules<SubCategoryType,DomainViewModel>
              
    {
        public SubCategoryTypeRules(IServiceHandlerFactory ServiceHandlerFactory) 
            : base(ServiceHandlerFactory){
        }

        public override bool Required { get; set; } = true;

        public override bool IsBaseRule => true;

        public override void RunRules(IBaseEntity Entity, EntityRules Entities, ModelStateDictionary modelState)
        {
            var e = (SubCategoryType)Entity;

                if (string.IsNullOrEmpty(e.SubCategoryTypeName))
                   modelState.AddModelError("", "Sub Cat Type Name cannot be emoty");

        }

        public override void RunRulesOnModel(IViewModel Entity, ModelStateDictionary modelState)
        {
            
        }
    }
}
