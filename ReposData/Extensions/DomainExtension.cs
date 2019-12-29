using Repos.DomainModel.Interface.DomainViewModels;
using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace ReposDomain.Extentions.Extensions
{
    public static class DomainExtension
    {
        public static void SetCleanViewModel<T>(this IViewModel<T> Model)
           where T : BaseEntity<T>
        {
            if (Model == null)
                return;

            Clean(Model);
        }

        public static void SetCleanModel<T>(this T Model)
          where T : DomainViewModel
        {
            if (Model == null)
                return;

            Clean(Model);

        }

        public static void SetCleanEntity <T>(this IDbSet<T> Entity)
           where T : BaseEntity<T>
        {
            if (Entity == null)
                return;

            Clean(Entity);

        }

        public static void SetCleanEntities<T>(this IQueryable<T> entities)
            where T : BaseEntity<T>
        {
            foreach ( var entity in entities)
              Clean(entity);
        }

        public static void SetCleanEntity<T>(this T Entity)
            where T : BaseEntity<T>
        {
            if (Entity == null)
                return;

            Clean(Entity);
             
        }
        
        public static void SetCleanEntity(object Entity)
        {
            if (Entity == null)
                return;

            Clean(Entity);

        }

        private static void Clean(object Entity)
        {
            var atributes = Entity
                      .GetType()
                      .GetProperties()
                      .Where(p => typeof(IDomainEntityType)
                      .IsAssignableFrom(p.PropertyType))
                      .ToList();

            foreach (var attr in atributes)
             {
                var value = attr.GetValue(Entity, null);
                if (value != null)
                     ((IDomainEntityType)(value)).SetClean();
             }
                                 
        }



    }
}
