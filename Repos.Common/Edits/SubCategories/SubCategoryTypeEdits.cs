using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;
using ReposServiceConfigurations.ServiceTypes.Edits;
using System;

namespace Repos.Common.Edits.SubCategories
{

    public class SubCategoryTypeEdits 
        : ReposDomainEdit<SubCategoryType>
        , IServiceEntityEdit<SubCategoryType>
    {


        public SubCategoryTypeEdits(IServiceHandlerFactory ServiceHandlerFactory)
            : base(ServiceHandlerFactory,null,null,null)
        {

        }

        public void RunEdits(SubCategory Entity)
        {
            throw new NotImplementedException();
        }

        
        public void SetEdits(SubCategory Entity){
        }

        public void RunEdits()
        {
            throw new NotImplementedException();
        }
             
        public void SetEntityDefaults(SubCategoryType Entity)
        {
            Entity.SubCategoryTypeName = "SubCategoryType";
        }

        public void SetEntityValues(SubCategoryType Entity)
        {
           // throw new NotImplementedException();
        }
    }
}