using System.Collections.Generic;
using Repos.DomainModel.Interface.Atrributes.DynamicAttributes;
using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.Filters;
using Repos.DomainModel.Interface.Interfaces.Filter;

namespace RepoUnitTest.Filters
{
    public class TestFilterAction : IDomainActionFilter
    {
        private dynamic retValue = default(dynamic);
        public void ApplyFilter(FilterParms parms)
        {
            retValue = parms.FilterSource;

        }

        public dynamic ReturnValue()
        {
            return retValue;
        }

        public void SetAttribute(DomainEntityType source)
        {
            throw new System.NotImplementedException();
        }

        public void SetAttribute(DomainEntityType source, IEnumerable<IFilterKeyPair> filters)
        {
            throw new System.NotImplementedException();
        }
    }
}
