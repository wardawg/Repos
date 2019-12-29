using Repos.DomainModel.Interface.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ReposDomainRules.RuleExtensions
{
    public static class ServiceRulesExtensions
    {
        
        public static bool In<T>(this T source, params T[] LookUpValues)
        {
            return LookUpValues.Contains(source);
        }

        static string GetPath<T>(Expression<Func<T, object>> memberExpression)
        {
            var bodyString = memberExpression.Body.ToString();
            string path = bodyString.Remove(0, memberExpression.Parameters[0].Name.Length + 1);
            return path;
        }

      
        public static IQueryable<T> Expand<T, TProperty>(this IQueryable<T> query
                            , Expression<Func<T, TProperty>> path) where T : BaseEntity<T>
        {
            return query.Include(path);
        }
                
    }

}
