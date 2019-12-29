using Repos.DomainModel.Interface.Filters;
using Repos.DomainModel.Interface.Interfaces.Filter;
using RepoUnitTest.Filters;
using System;

namespace RepoUnitTest.Factories
{
    public class TestFilterFactory : IFilterFactory
    {
        public IFilterConstants FilterConstants => throw new NotImplementedException();

        public IFilter GetFilter(FilterParms AvailableFilters)
        {
            var filter = default(IDomainActionFilter);

            switch(AvailableFilters.FilterEnum.ToString())
            {
                case "TestFilter":
                    filter = new TestFilterAction();
                    break;
                case "TestSubCategoryFilter":
                    filter = new TestSubCategoryFilter();
                    break;
            }

            return filter;
        }
            
        
    }

}
