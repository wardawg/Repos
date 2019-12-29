using System;
using Repos.DomainModel.Interface.Interfaces;
using ReposCore.Infrastructure;
using Repos.DomainModel.Interface.DomainViewModels;
using ReposServiceConfigurations.ServiceTypes.Rules;
using ReposServiceConfigurations.Common;
using System.Collections.Generic;

namespace RepoUnitTest.Rules

{
    class TestSubCategoryRules : IRule
    {
        public IClientInfo Client => new DefaultClientInfo();

        public IEntityRule CreateRule<D, M>()
        {
            return EngineContext
                  .Current
                  .ContainerManager
                  .Resolve<IEntityRule<D, M>>() as IEntityRule<D, M>;
             
        }
          

        public IEntityRule GetDomainRules(IBaseEntity baseEntity)
        {
            return null;
        }

        public IEntityRule GetDomainRules(Type t)
        {
            throw new NotImplementedException();
        }

        public IEntityRule GetDomainRule(IBaseEntity baseEntity, IClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        public IEntityRule GetDomainRule(Type t, IClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        public IEntityRule GetViewModelRule(IDomainViewModel ViewModelEntity)
        {
            return null; 
        }

        IEnumerable<IEntityRule> IRule.GetDomainRules(IBaseEntity baseEntity, IClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }
 

        public IEnumerable<IEntityRule> GetDomainRules(Type t, IClientInfo clientInfo, string[] sRule = null)
        {
            throw new NotImplementedException();
        }
    }
}
