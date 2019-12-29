using Repos.DomainModel.Interface.Interfaces.Filter;

namespace ReposDomain.Filters
{

    public enum ReposFilters
    {
        CatNCatTypeDDLFilter
      , CatNCatTypeDDLRestFilter
      , GenericFilter

    }

    public class FilterConstants 
           : IFilterConstants
    {
       

        public static  ReposFilters Filters => new ReposFilters();

    }
}
