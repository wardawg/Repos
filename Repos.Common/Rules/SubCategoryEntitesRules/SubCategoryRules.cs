using Repos.DomainModel.Interface.Custom.Types;
using Repos.DomainModel.Interface.Interfaces;
using Repos.Models.SubCategories;
using ReposDomain.Domain;
using ReposDomain.Handlers.Handlers;
using ReposDomain.Rules;
using ReposDomainRules.RuleExtensions;
using System.Collections.Generic;
using System.Linq;
using ModelStateDictionary = Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace Repos.Common.Rules.SubCategoryEntitesRules
{

    public class SubCategoryRules 
        : DomainBaseRules<SubCategory, SubCategoryModel>
                
    {
        public SubCategoryRules(IServiceHandlerFactory ServiceHandlerFactory) 
            : base(ServiceHandlerFactory){
        }

        //' public bool Required { get; private set; } = true;

        public new bool Required { get => true; }
       // public new override bool Required { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // public override bool Required { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool IsBaseRule =>true;

        public override void RunRules(IBaseEntity  Entity
                                    , EntityRules entitiesRules
                                    , ModelStateDictionary modelState)
        {
                        
            var name = string.Empty;

            var SubCat = GetEntity<SubCategory>(entitiesRules);
                   
            var exists = _ServiceHandlerFactory.Using<ISubCategoryHandler>().Get()
                       .Where(c => c.SubCategoryName.Value == SubCat.SubCategoryName.Value)
                       .AsEnumerable().Any(w => SubCat.IsNew || 
                        (SubCat.OldPicture !=null 
                           && SubCat.OldPicture.SubCategoryName.Value != w.SubCategoryName.Value));


            if (exists)
            {
                modelState.AddModelError("", "Found Duplicate Sub Category Name");
            }
            
                       
        }
             

        public virtual void RunRulesOnModel(SubCategory Entity, ModelStateDictionary modelState)
        {
            IEnumerable<Category> cats = _ServiceHandlerFactory
                       .Using<ICategoryHandler>()
                       .Get();
           

            var cat_type = _ServiceHandlerFactory
                             .Using<ICategoryTypeHandler>()
                             .Get();

        
            var subCategory = (SubCategory)Entity;

            if (subCategory.CategoryId.Value == 5 && ! subCategory.CategoryTypeId.Value.In(1, 3))
                modelState
                .AddModelError(""
                    , string.Format("Category Type for {0} Must Be XX"
                                    , GetNameValue<Category>(subCategory.CategoryId, cats).CategoryName.Value
                                    )
                                );
        }

        public override void RunRulesOnModel(IViewModel Entity, ModelStateDictionary modelState){
        }
             

        public override void SetViewModelRules(dynamic RuleFactory, bool cleanState = true){
        }

        public override void ValidModelRules(dynamic RuleFactory, dynamic modelstate,IClientInfo client){
        }
    }
};