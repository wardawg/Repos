using Repos.Common.Rules.SubCategoryEntitesRules;
using Repos.DomainModel.Interface.DomainViewModels;
using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Validation.Rules;
using ReposServiceConfigurations.Common;
using ReposServiceConfigurations.ServiceTypes.Rules;
using RepoUnitTest.Entities;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ServiceRules.Factory
{


    public class TestRulesFactory : IRule
    {
        public IClientInfo Client => new DefaultClientInfo();

        bool GetGenericTypeIsImplemator(Type type,string rulename)
        {
           
            bool t = type.GetGenericArguments()
                        .FirstOrDefault().Name == rulename;
            return t;
        }

        public IEntityRule GetDomainRule(IBaseEntity baseEntity)
        {
            return baseEntity == null ? null : GetDomainRule(baseEntity.ObjName);
        }

        public IEntityRule GetDomainRule(string ruleName)
        {
            IEntityRule rule = default(IEntityRule);
            switch (ruleName)
            {

              //  case "SubCategory":
             //   case "TestEntity":
              //      rule = new TestViewModel();
               //     break;
                case "TestEntityError":
                    rule = new TestEntityError();
                    break;
                case "TestSubCategory":
                    Moq.Mock<SubCategoryRules> _mockSubCategoryRules
                        = new Moq.Mock<SubCategoryRules>() { CallBase = false };
                    rule = _mockSubCategoryRules.Object;
                    break;
                
                default:
                    var _mock = new Moq.Mock<IServiceHandlerFactory>();
                    rule = new TestEntityRule(_mock.Object);
                    break;

            }

            return rule;
        }

        public IEntityRule CreateRule<D, M>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntityRule> GetViewModelRule(IDomainViewModel ViewModelEntity)
        {
            throw new NotImplementedException();
        }

        public IEntityRule GetDomainRule(Type t)
        {
            return GetDomainRule(t.Name);
            //throw new NotImplementedException();
        }

        public IEntityRule GetDomainRules(IBaseEntity baseEntity, IClientInfo clientInfo)
        {
            return GetDomainRule(baseEntity.GetType());
            // throw new NotImplementedException();
        }

        public IEntityRule GetDomainRule(Type t, IClientInfo clientInfo)
        {
            return GetDomainRule(t);
        }

        IEnumerable<IEntityRule> IRule.GetDomainRules(IBaseEntity baseEntity, IClientInfo clientInfo)
        {
            return new List<IEntityRule>()
                {
                    GetDomainRule(baseEntity)
                };

           
        }

      
        public IEntityRule GetDomainRule(IBaseEntity baseEntity, IClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        IEntityRule IRule.GetDomainRule(Type t, IClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }

        IEntityRule IRule.GetViewModelRule(IDomainViewModel ViewModelEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntityRule> GetDomainRules(Type t, IClientInfo clientInfo, string[] sRule = null)
        {
            throw new NotImplementedException();
        }
    }
}
