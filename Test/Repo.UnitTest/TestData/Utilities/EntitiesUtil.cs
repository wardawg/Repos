using Repos.DomainModel.Interface.Interfaces;
using ReposServiceConfigurations.ServiceTypes.Base;
using System;
using System.Reflection;

namespace RepoUnitTest.Utilities
{
    public static class EntitiesUtil
    {

        public static Moq.Mock CreateMock(Type t)
        {
            //Type[] typeParams = new Type[] { typeof(IBaseService<BaseEntity<TestSubCategory>>) };

            Type[] typeParams = new Type[] {};

            Type constructedType = typeof(Moq.Mock<>).MakeGenericType(typeParams);

            //var instance = CreateInstance(typeof(Mock<T>), typeof(T)) as Mock<T>;

            return Activator.CreateInstance(constructedType) as Moq.Mock;
        }

        public static IBaseService CreateServerInstance(Type t, params object[] paramArray)
        {
            return Activator.CreateInstance(t, paramArray) as IBaseService;
        }

        public static IBaseEntity CreateInstance(Type t, params object[] paramArray)
        {
            return Activator.CreateInstance(t, true) as IBaseEntity;
        }



        public static T CreateEntity<T>()
        {
            var Entity = Activator.CreateInstance(typeof(T), true);
            return (T)Entity;
        }

        public static void SetEntityId(IBaseEntity entity,object Id)
        {
           
            FieldInfo oField
                    = entity.GetType().GetField("idValue"

                    , BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance
                    | BindingFlags.IgnoreCase);

            oField.SetValue(entity, Id);
            
        }
       
}
}
