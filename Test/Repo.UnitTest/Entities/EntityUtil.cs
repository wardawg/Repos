using ProjectDependResolver;
using ReposCore.Infrastructure;
using ReposData.Utilities;
using ReposServiceConfigurations.ServiceTypes.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepoUnitTest.Entities
{
    public class Util
    {

        public static IEnumerable<EntityMapType> GetMap<T>()
        {
            
            if (EngineContext.Current == null)
                return new List<EntityMapType>();

            var interfaceName = typeof(T).Name;

            var maps = EngineContext
                                  .Current
                                  .ContainerManager
                                  .Resolve<ITypeFinder>()
                                  .FindClassesOfType<T>()
                                  .Where(w => !w.ContainsGenericParameters
                                           && w.Assembly.FullName != typeof(Util).Assembly.FullName
                                           && !w.GetCustomAttributes(typeof(NoServiceResolveAtrribute), true)
                                         .Any()
                                  )
                                  .Select(s => new EntityMapType
                                  {
                                      EntityType = s
                                      ,EntityTypeName = s.Name
                                     ,InheritNumber = GetTypeInheritsNumber(s)
                                     , AssmName = s.Assembly.FullName.Split(',').First()
                                  });

          var t=  maps
                        .Where(w =>
                                maps
                                .Where(w2 => w.EntityType.IsSubclassOf(w2.EntityType)
                                     )
                                .Any())
                                .Select(s => new
                                {
                                    EntityTypeName = s.EntityTypeName
                                    ,InheritNumber = s.InheritNumber
                                    ,AssmName      = s.AssmName
                                })
                            ;

      
            var Inherited = maps
                            .Where(w =>
                                    maps
                                    .Where(w2 => w.EntityType.IsSubclassOf(w2.EntityType))
                                    .Any())
                                    .Select(s => new
                                    {
                                        EntityTypeName = s.EntityTypeName
                                        ,InheritNumber = s.InheritNumber
                                        ,AssmName      = s.AssmName
                                                         .Split(',')
                                                         .First()
                                    });

            var EntityTypes = default(IEnumerable<EntityMapType>);

            if (Inherited.Any()) {
               EntityTypes =
                      maps
                        .Select(s => new
                        {
                            EntityTypeName = s.EntityTypeName
                           , InheritNumber = s.InheritNumber
                           ,AssmName       = s.AssmName
                                             .Split(',')
                                             .First()
                        }
                        ).Except(Inherited)
                         .Select(s =>
                                   new EntityMapType
                                   {
                                     EntityTypeName = s.EntityTypeName
                                   , InheritNumber = s.InheritNumber
                                   , EntityType = null
                                   , AssmName = s.AssmName
                                   }
                               );
            } 


            System.Diagnostics.Debug.Assert(true);

            return EntityTypes != null ? EntityTypes : new List<EntityMapType>();

        }

        
        private static int GetTypeInheritsNumber(Type t)
        {
            Type tempType = t;
            int typeOrder = 0;

            do


                if (tempType.BaseType != null && tempType.BaseType != typeof(Object))
                {
                    typeOrder++;
                    if (tempType.BaseType.IsGenericType)
                        break;
                    else
                        tempType = tempType.BaseType;
                }
                else
                    break;

            while (true);

            return typeOrder;
        }
    }
}
