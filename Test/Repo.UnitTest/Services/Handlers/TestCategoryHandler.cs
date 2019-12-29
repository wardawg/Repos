using Repos.DomainModel.Interface.DomainComplexTypes;
using ReposDomain.Domain;
using ReposDomain.Handlers.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Repos.DomainModel.Interface.Filters;
using Repos.DomainModel.Interface.Interfaces.Filter;
using Repos.DomainModel.Interface.Interfaces;

namespace RepoUnitTest.Services.Handler
{
    public class TestCategoryHandler : ICategoryHandler
    {
        public List<Category> Get()
        {
            return GetCategories().ToList();
            //throw new NotImplementedException();
        }

        public IQueryable<Category> Get<TFilter>() where TFilter : IEditFilter
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetCategories()
        {
            IList<Category> lCat = new List<Category>();

            for (int i = 1; i < 3; i++)
            {

                Category cat = (Category)Activator.CreateInstance(typeof(Category), true);

                PropertyInfo oProp
                        = cat.GetType().GetProperty("Id"
                        , BindingFlags.NonPublic
                        | BindingFlags.Public
                        | BindingFlags.Instance
                        | BindingFlags.IgnoreCase);
                cat.CategoryName = new DomainEntityTypeString { Value = "Default" };
                oProp.SetValue(cat, i);
                lCat.Add(cat);
            }

            return new List<Category>(lCat).AsQueryable();
        }

        public IFilter GetFilter<TFilter>() where TFilter : IEditFilter
        {
            throw new NotImplementedException();
        }


    }
}

