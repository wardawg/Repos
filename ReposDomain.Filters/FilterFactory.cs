using Repos.DomainModel.Interface.Interfaces.Filter;
using ReposDomain.Filters.Base;

namespace ReposDomain.Filters

{
    public class FilterFactory
        : BaseFilterFactory<FilterFactory, FilterConstants>
    {

        public FilterFactory() { }

        public FilterFactory(IFilterConstants<FilterConstants> constant){
        }

    }
}
