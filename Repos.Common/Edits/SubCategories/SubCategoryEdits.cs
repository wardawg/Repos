using Repos.DomainModel.Interface.Atrributes.DynamicAttributes;
using Repos.DomainModel.Interface.Interfaces;
using Repos.DomainModel.Interface.Interfaces.DomainList;
using Repos.DomainModel.Interface.Interfaces.Filter;
using ReposDomain.Domain;
using ReposDomain.Handlers.Handlers;
using ReposServiceConfigurations.Extensions;
using ReposServiceConfigurations.ServiceTypes.Edits;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using EditReposFilters = ReposDomain.Filters.ReposFilters;

namespace Repos.Common.Edits.SubCategories
{


    public class SubCategoryEdits 
        : ReposDomainEdit<SubCategoryEdits>
        , IServiceEntityEdit<SubCategory>
    {

        public SubCategoryEdits(IServiceHandlerFactory ServiceHandlerFactory
                                ,IFilterFactory        FilterFactory
                                ,IListFactory          ListFactory
                                ,ICommonInfo           CommonInfo
                                )
            :base(ServiceHandlerFactory, FilterFactory, ListFactory,CommonInfo)
        {
       
        }
        

        public void RunEdits()
        {
            throw new NotImplementedException();
        }

        public virtual void SetEntityDefaults(SubCategory Entity)
        {
            Entity.SubCategoryName.Value = "Default";
            if (AddDomainAttributes)
                SetEntityValues(Entity);
        }
                        
        public virtual void SetEntitiesFilters(SubCategory Entity)
        {

            _FilterFactory
                .Using<IFilterKeyPair>(EditReposFilters.CatNCatTypeDDLFilter,_CommonInfo.ClientInfo)
                .SetValue(Entity.CategoryTypeId);

        }

             

        public virtual void SetEntitiesProps(SubCategory Entity)
        {
            dynamic attr  = new ExpandoObject();
            attr.propList = new List<PropListKeyPair>();


            //IPropFilter

            _ServiceHandlerFactory
               .Using<ICategoryTypeHandler>(ClientInfo)
               .SetPropValues(Entity.CategoryTypeId, "CategoryTypeName");


            //_ServiceHandlerFactory
            //    .Using<ICategoryTypeHandler>(ClientInfo)
            //    .SetPropValues(Entity, propName);


            


            //_ServiceHandlerFactory
            //    .Using<ICategoryTypeHandler>()
            //    .Get<ICategoryTypeEditFilter>()
            //    .ToList()
            //    .ForEach(s => attr.propList.Add(
            //                new PropListKeyPair()
            //                {
            //                    Key = s.Id.ToString()
            //                    ,
            //                    Value = s.CategoryTypeName
            //                }));



            attr.Required = true;

            Entity
                .CategoryTypeId
                .Attributes = attr;

            attr = new ExpandoObject();
            attr.propList = new List<PropListKeyPair>(); 
            
            _ServiceHandlerFactory
                .Using<ICategoryHandler>()
                .Get()
                .ToList()
                .ForEach(s => attr.propList.Add(
                    new PropListKeyPair()
                    {
                        Key = s.Id.ToString()
                         ,
                        Value = s.CategoryName.Value
                    }));

            attr.Required = true;

            Entity
                .CategoryId
                .Attributes = attr;


        }

        public virtual void SetEntityValues(SubCategory Entity)
        {

            SetEntitiesProps(Entity);
            SetEntitiesFilters(Entity);
                 
        }
    }
}
 