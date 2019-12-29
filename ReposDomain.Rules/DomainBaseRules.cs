using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repos.DomainModel.Interface.Custom.Types;
using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.Interfaces;
using ReposServiceConfigurations.ServiceTypes.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ModelStateDictionary = Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace ReposDomain.Rules
{
    public class DomainBaseRules{
    }
        public abstract class DomainBaseRules<D,M>
            : DomainBaseRules
            , IEntityRule<D,M>
            , IBaseViewModelRule
            where D : BaseEntity<D>
          
        {
            protected readonly IServiceHandlerFactory _ServiceHandlerFactory;

            public virtual bool Required { get; set; } = true;
            public virtual bool IsBaseRule { get; }
  

        public DomainBaseRules(IServiceHandlerFactory ServiceHandlerFactory)
        {
            _ServiceHandlerFactory = ServiceHandlerFactory;
        }


        

        protected TEntity GetEntity<TEntity>(EntityRules Entities, Expression<Func<TEntity, bool>> predicate =   null) 
            where TEntity : BaseEntity<TEntity>
        {
            Func<TEntity, bool> deg = i => true;
            Expression<Func<TEntity, bool>> expr = i => true;

            var p = predicate == null ? expr : predicate;


            var ret = Entities
                    .Rules
                    .Values
                    .OfType<TEntity>()
                    .AsQueryable()
                    .Where(p)
                    .FirstOrDefault();

            return ret;
                   
        }

        protected TValue GetNameValue<TValue>(DomainEntityType entityType,IEnumerable<TValue> List)
            where TValue : BaseEntity<TValue>
        {
            return GetNameValue(((dynamic)entityType).Value, List);
        }
        protected TValue GetNameValue<TValue>(dynamic Id, IEnumerable<TValue> List) 
            where TValue : BaseEntity<TValue>
        {
            return (TValue)List.Where(n => n.Id == Id).FirstOrDefault();
        }

        public abstract void RunRules(IBaseEntity Entity
                                    , EntityRules Entities
                                    , ModelStateDictionary modelState);
        

        public abstract void RunRulesOnModel(IViewModel Entity
                                           , ModelStateDictionary modelState);
        //{
            //var modelName = Entity.GetType().Name;
            //    switch (modelName)
            //{
            //    case "SubCategoryModel":
            //        var Name = ((SubCategoryModel)Entity).SubCategoryName.Value;
            //        if (string.IsNullOrEmpty(Name))
            //            modelState.AddModelError("", "Name is empty in SubCategoryModel");

            //       break;
            //}

       // }

        public virtual void ValidModelRules(dynamic RuleFactory
                                            , dynamic modelstate
                                            , IClientInfo client)
        { }

        public virtual void SetViewModelRules(dynamic RuleFactory
                                            , bool cleanState = true)
        { }

        public void SetViewModelRules(dynamic RuleFactory, IClientInfo client, bool cleanState)
        {
        }

     
    }
}
