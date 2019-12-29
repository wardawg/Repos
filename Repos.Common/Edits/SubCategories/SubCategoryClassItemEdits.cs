using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;
using ReposServiceConfigurations.ServiceTypes.Edits;
using System;

namespace Repos.Common.Edits.SubCategories
{
    public class SubCategoryClassItemEdits
        : ReposDomainEdit<SubCategoryClassItem>
        , IServiceEntityEdit<SubCategoryClassItem>
    {
        public SubCategoryClassItemEdits(IServiceHandlerFactory ServiceHandlerFactory)
            : base(ServiceHandlerFactory,null,null,null)
        {

        }
        public void RunEdits()
        {
            throw new NotImplementedException();
        }

        public void SetEntityDefaults(SubCategoryClassItem Entity)
        {
            Entity.SubCategoryClassItemName = "SubCategoryClassItem";
        }

        public void SetEntityValues(SubCategoryClassItem Entity)
        {
            throw new NotImplementedException();
        }
    }
}
