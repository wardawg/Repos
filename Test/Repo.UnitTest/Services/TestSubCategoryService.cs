using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repos.DomainModel.Interface.Interfaces;
using ReposCore.Extensions;
using ReposCore.FunctionInterfaces;
using ReposDomain.Domain;
using ReposServiceConfiguration.ServiceTypes.Base;
using ReposServiceConfigurations.ServiceTypes.Base;
using ReposServices.SubCategoriesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using ModelStateDictionary = System.Web.Mvc.ModelStateDictionary;

namespace RepoUnitTest.Services
{
    class TestSubCategoryService : ISubCategoriesService
    {
        public void Add(SubCategory Entity)
        {
            throw new NotImplementedException();
        }

        public SubCategory CreateServiceEntity()
        {
            throw new NotImplementedException();
        }

        public SubCategory CreateServiceEntity(CreateEntityOptions createEntityOptions)
        {
            throw new NotImplementedException();
        }

        public SubCategory CreateServiceEntity(IClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubCategory Entity)
        {
            throw new NotImplementedException();
        }

        public IList<SubCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<SubCategory> GetAllSubCategories()
        {
            throw new NotImplementedException();
        }

        public SubCategory GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public SubCategory GetSubCategoriesById(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public void Insert(SubCategory Entity)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }


      
        public bool Save(ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }

        public Result Save(ModelStateDictionary ModelState, IClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        public void SetEntitiesValues(SubCategory Entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SubCategory Entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SubCategory Entity, IClientInfo client)
        {
            throw new NotImplementedException();
        }

        public Result Verify(ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }

        public Result Verify(ModelStateDictionary ModelState, IClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        public Result Verify(ServiceRuleFunc<bool> ServiceRuleFunc, ModelStateDictionary modelState, object RuleFactory)
        {
            throw new NotImplementedException();
        }

        public Result Verify(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }

        public Result Verify(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary ModelState, IClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubCategory> Where(Expression<Func<SubCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

         
        Result IBaseService<SubCategory>.Delete(SubCategory Entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<SubCategory> IBaseService<SubCategory>.GetAll()
        {
            throw new NotImplementedException();
        }

        //Result IBaseService<SubCategory>.Save()
        //{
        //    throw new NotImplementedException();
        //}

        //Result IBaseService<SubCategory>.Save(ModelStateDictionary ModelState)
        //{
        //    throw new NotImplementedException();
        //}

        void IBaseService<SubCategory>.Update(SubCategory Entity)
        {
            throw new NotImplementedException();
        }
    }
}
