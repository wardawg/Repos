using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;
using Repos.DomainModel.Interface.DomainViewModels;
using ReposDomain.Rules;
using System;
using ReposData.Custom.Types;
using System.Web.Mvc;

namespace Repos.Common.Rules.SubCategoryEntitesRules
{
    public partial class SubCategoryClassItemRules
        : DomainBaseRules<SubCategoryClassItem,DomainViewModel>
    {
        public SubCategoryClassItemRules(IServiceHandlerFactory ServiceHandlerFactory) 
            : base(ServiceHandlerFactory)
        {
        }
                     

        public override bool IsBaseRule => true;

        public override bool Required { get; set; } = true;

        public override void RunRules(IBaseEntity Entity, EntityRules Entities, ModelStateDictionary modelState)
        {
        
        }

        public override void RunRulesOnModel(IViewModel Entity, ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }
}
