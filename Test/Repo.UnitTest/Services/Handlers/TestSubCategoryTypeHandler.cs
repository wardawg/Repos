using System;
using System.Linq;
using ReposDomain.Domain;
using ReposDomain.Handlers.Handlers;
using System.Collections.Generic;
using System.Reflection;
using Repos.DomainModel.Interface.Filters;
using Repos.DomainModel.Interface.Interfaces.Filter;

namespace RepoUnitTest.Services.Handler
{
    public class TestCategoryTypeHandler : ICategoryTypeHandler
    {
        public List<CategoryType> Get()
        {
            List<CategoryType> lCat = new List<CategoryType>();

            for (int i = 1; i < 3; i++)
            {

                CategoryType cat = (CategoryType)Activator.CreateInstance(typeof(CategoryType), true);

                PropertyInfo oProp
                        = cat.GetType().GetProperty("Id"
                        , BindingFlags.NonPublic
                        | BindingFlags.Public
                        | BindingFlags.Instance
                        | BindingFlags.IgnoreCase);
                cat.CategoryTypeName = string.Format("Default-{0}",i);
                oProp.SetValue(cat, i);
                lCat.Add(cat);
            }

            return lCat; 
        }

        public IQueryable<CategoryType> Get<TFilter>() where TFilter : IEditFilter
        {
            throw new NotImplementedException();
        }

        public IFilter GetFilter<TFilter>() where TFilter : IEditFilter
        {
            throw new NotImplementedException();
        }
    }
}
