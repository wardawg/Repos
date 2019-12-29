using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Handlers.Base;
using ReposServiceConfigures.ServiceTypes.Handlers;
using System;
using System.Linq;
using ReposData.Repository;

namespace RepoUnitTest.Services.Handler
{
    public class TestServiceHandlerFactory : IServiceHandlerFactory
    {
        private ReposContext context;

        public TestServiceHandlerFactory()
        {

        }
               
        public TestServiceHandlerFactory(ReposContext context)
        {
            this.context = context;
        }

        public T Using<T>() where T : class, IHandler
        {
            var handler = default(T);
            var name = typeof(T).Name;

            switch (name)
            {
                
                case "IServiceGenericHandler":
                //    if (context != null)
                //        handler = new GenericHandler(context) as T;
                //    else
                        handler = new TestGenericHandler() as T;
                    break;
                case "ICategoryHandler":
                    handler = new TestCategoryHandler() as T;
                    break;
                case "ISubCategoryHandler":
                    handler = new TestSubCategoryHandler() as T;
                    break;

                case "ICategoryTypeHandler":
                    handler = new TestCategoryTypeHandler() as T;
                    break;
                default:
                    Type type = typeof(IServiceHandler).Assembly
                                .GetTypes()
                                .Where(t => typeof(IServiceHandler).IsAssignableFrom(t)
                                        && t.GetInterface(name, true) != null).FirstOrDefault();

                    handler = type == null ? null: Activator.CreateInstance(type, true) as T;
                    break;
            }
            
            return handler;
            
        }

        T IServiceHandlerFactory.Using<T>(IClientInfo Client)
        {
            return Using<T>();
        }
    }
}
