using Repos.DomainModel.Interface.DomainComplexTypes;
using ReposDomain.Domain;
using ReposDomain.Handlers.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RepoUnitTest.Services.Handler
{
    public class TestSubCategoryHandler : ISubCategoryHandler
    {
        public IReadOnlyList<Category> AvailCoverages()
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
                    cat.CategoryName =  new DomainEntityTypeString { Value = "Default" };
                    oProp.SetValue(cat, i);
                    lCat.Add(cat);
              }

                return new List<Category>(lCat);
        }

        public IQueryable<SubCategory> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubCategory> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

