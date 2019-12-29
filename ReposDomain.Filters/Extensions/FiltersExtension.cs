using Repos.DomainModel.Interface.Filters;
using Repos.DomainModel.Interface.Interfaces.Filter;
using System;

namespace ReposDomain.Filters.Extensions
{
    
    public static class FilterExtension
    {

        public static bool TryParse<T>(this Enum theEnum, string valueToParse, out T returnValue)
        {
            returnValue = default(T);
            int intEnumValue;
            if (Int32.TryParse(valueToParse, out intEnumValue))
            {
                if (Enum.IsDefined(typeof(T), intEnumValue))
                {
                    returnValue = (T)(object)intEnumValue;
                    return true;
                }
            }
            return false;
        }

        public static T AsFilter<T>(this object c) where T : struct
        {
            return (T)System.Enum.Parse(typeof(T), c.ToString(), false);
        }
    
        public static dynamic ApplyFilter<T>(this T value
                                            , FilterParms parms)
        {

            //IDomainActionFilter filter = parms.Factory.GetFilter(parms) as IDomainActionFilter;
            dynamic filter = parms.Factory.GetFilter(parms);
            parms.FilterSource = value;
           
            filter.ApplyFilter(parms);

            return filter.ReturnValue();
        }
    }
}
