using Repos.DomainModel.Interface.Interfaces;
using ReposData.Custom.Types;
using ReposDomain.Domain;
using ReposDomain.Handlers.Handlers;
using ReposDomainRules.RuleExtensions;
using System.Collections.Generic;
using ModelStateDictionary = Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;


namespace NewOrder.Rules.Domain.SubCategoryEntitesRules
{

    public class SubCategoryRules
        : Repos.Common.Rules.SubCategoryEntitesRules.SubCategoryRules
    {
        public SubCategoryRules(IServiceHandlerFactory ServiceHandlerFactory)
            : base(ServiceHandlerFactory)
        {
        }


        public void SetViewModelRules(SubCategory viewModel)
        {
            viewModel.CategoryId.Enabled = false;
            viewModel.CategoryTypeId.Enabled = false;
        }

        public override void RunRules(IBaseEntity Entity
                                    , EntityRules entitiesRules
                                    , ModelStateDictionary modelState)
        {

            
            var subCategoryType = GetEntity<SubCategoryType>(entitiesRules);
            var subCategoryItem = GetEntity<SubCategoryClassItem>(entitiesRules);

            if (subCategoryType == null)
                modelState.AddModelError("", "New Order SubCategory must contain one Sub Type");
            if (subCategoryItem == null)
                modelState.AddModelError("", "New Order SubCategory must contain one Sub Item");


        }

        //    public override void RunRulesOnModel(SubCategory Entity, ModelStateDictionary modelState)
        //    {
        //        IEnumerable<Category> cats = _ServiceHandlerFactory
        //                   .Using<ICategoryHandler>()
        //                   .Get();

        //        var subCategory = Entity as SubCategory;

        //        if (subCategory.CategoryId.Value == 5 && ! subCategory.CategoryTypeId.Value.In(1, 3))
        //            modelState
        //            .AddModelError(""
        //                , string.Format("New Order Category Type for {0} Must Be XX"
        //                                , GetNameValue<Category>(subCategory.CategoryId, cats).CategoryName.Value
        //                                )
        //                            );
        //    }
        //}
    }
}
  