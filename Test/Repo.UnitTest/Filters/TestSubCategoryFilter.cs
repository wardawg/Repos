using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.Filters;
using Repos.DomainModel.Interface.Interfaces.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using Repos.DomainModel.Interface.Atrributes.DynamicAttributes;

namespace RepoUnitTest.Filters
{
    public class TestSubCategoryFilter : IDomainActionFilter
    {
        private dynamic retValue = default(dynamic);
        public void ApplyFilter(FilterParms parms)
        {
            var key = parms.ParmInputs.Keys.First();
            dynamic retValue = parms.ParmInputs[key];
               
            var Filter  = new List<string>();
            
            Filter.Add("SomeValue1");
            Filter.Add("SomeValue2");
            Filter.Add("SomeValue3");
            Filter.Add("SomeValue4");
                         
            ((IDictionary<String, Object>)retValue.Attributes)[key] = Filter;
            
        }

        public dynamic ReturnValue()
        {
            return retValue;
        }

        public void SetAttribute(DomainEntityType source)
        {
            throw new NotImplementedException();
        }

        public void SetAttribute(DomainEntityType source, IEnumerable<IFilterKeyPair> filters)
        {
            throw new NotImplementedException();
        }
    }
}
