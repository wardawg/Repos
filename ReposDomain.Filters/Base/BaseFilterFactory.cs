using Repos.DomainModel.Interface.Filters;
using Repos.DomainModel.Interface.Interfaces;
using Repos.DomainModel.Interface.Interfaces.Filter;
using ReposCore.Infrastructure;
using System;
using ReposServiceConfigurations.Common;
using Repos.DomainModel.Interface.Atrributes.DynamicAttributes;
using ProjectDependResolver;

namespace ReposDomain.Filters.Base
{

    public class CreateFilterGenericType<T>
        : IFilterConstants<T>
        where T : new()
    {
        public T Filters { get => new T(); }
    }

    public class CreateFilter<T>
        where T : FilterConstants, new()
    {
        public CreateFilter(IFilterConstants<T> filter){
        }
    }
        
    public abstract class BaseFilterFactory<TClass,TFilter>
        : IFilterFactory
        where TClass : class
        where TFilter : class,new()
    {
        protected IFilterConstants<TFilter> 
             _filterConstants = new CreateFilterGenericType<TFilter>();
        protected IEngine HandlerResolve = EngineContext.Current;
                        
        public IFilterConstants FilterConstants { get => _filterConstants; }
        
        public IFilter GetFilter(FilterParms AvailableFilters)
        {
            var filterName = AvailableFilters.FilterEnum.ToString();
            return GetFilterByName<IDomainActionFilter>(filterName);
        }

        private dynamic GetFilterByName<T>(string filterName="")
            where T : class,IFilter
        {
           
            return EngineContext
                   .Current
                   .ContainerManager
                   .Resolve<T>(filterName);
        }

         
    }
}
