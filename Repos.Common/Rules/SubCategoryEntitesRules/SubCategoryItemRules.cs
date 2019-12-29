using Repos.DomainModel.Interface.DomainViewModels;
using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;
using ReposDomain.Rules;
using System.Collections.Generic;
using System;
using ReposCore.Custom.Types;
using System.Web.Mvc;

namespace Repos.Common.Rules.SubCategoryEntitesRules
{

    public class SubCategoryItemRules 
        : DomainBaseRules<SubCategoryItem, DomainViewModel>
        {
        public SubCategoryItemRules(IServiceHandlerFactory ServiceHandlerFactory) 
            : base(ServiceHandlerFactory)
        {
        }

        public override bool Required { get; set; } = true;

        public override bool IsBaseRule => true;

        public IEnumerable<string> RunRules(IBaseEntity Entity)
        {
            var errors = new List<string>();
           
            return errors;
         
        }

        public override void RunRules(IBaseEntity Entity, EntityRules Entities, ModelStateDictionary modelState)
        {
        }

        public override void RunRulesOnModel(IViewModel Entity, ModelStateDictionary modelState)
        {
        }
    }
}