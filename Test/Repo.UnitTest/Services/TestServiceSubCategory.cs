using ReposData.Repository;
using ReposDomain.Domain;
using ReposServiceConfigurations.ServiceTypes.Edits;
using ReposServiceConfigurations.ServiceTypes.Rules;
using ReposServices.SubCategoriesServices;
using RepoUnitTest.Utilities;

namespace RepoUnitTest.Services
{
    class TestServiceSubCategory : SubCategoriesService

    {
        public TestServiceSubCategory(IRepository<SubCategory> subCategoryRepository
                                      , IServiceEntityEdit<SubCategory> Edits
                                      , IEntityRule RulesFactory)
            : base(subCategoryRepository,null, null, null)
        { }
            public override SubCategory GetById(object Id)
        {
            var cat = CreateServiceEntity();

            EntitiesUtil.SetEntityId(cat,Id);
            cat.SubCategoryName.Value = this.GetType().Name;
            cat.CategoryId.Value = 1;
            cat.CategoryTypeId.Value = 1;
            return cat;
        }
        
    }
}
