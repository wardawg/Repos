using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;
using ReposServiceConfigurations.ServiceTypes.Edits;
using System;

namespace Repos.Common.Edits.SubCategories
{

    public class SubCategoryItemEdits 
        : ReposDomainEdit<SubCategoryItem>
        , IServiceEntityEdit<SubCategoryItem>
    {
         

        public SubCategoryItemEdits(IServiceHandlerFactory ServiceHandlerFactory)
            : base(ServiceHandlerFactory,null,null,null)
        {

        }

        public void RunEdits()
        {
            throw new NotImplementedException();
        }

        public virtual void SetEntityDefaults(SubCategoryItem Entity)
        {
            Entity.SubCategoryItemName = "Default";
        }

        public void SetEdits(SubCategoryItem Entity)
           {

           // IRepository<SubCategoryType> sctype = new EfRepository<SubCategoryType>(_IDbContext);
          //  var sc = sctype.Where(c => c.SubCategoryId == 6).SingleOrDefault();
                    
           }

        public void SetEntityValues(SubCategoryItem Entity)
        {
            throw new NotImplementedException();
        }
    }
}