using Repos.DomainModel.Interface.Interfaces;
using System;
using System.Linq;

namespace Repos.Models
{
    public abstract class ViewModel { }
        
    public abstract class ViewModel<T>
        : BaseViewModel<T>
         ,IViewModel<T>
        ,IBaseViewModelRule
        
    where T : BaseEntity<T>
    {
               
        void IBaseViewModelRule.ValidModelRules(dynamic RuleFactory, dynamic modelstate, IClientInfo client)
        {
            
            var name = GetEntityNameFromModel();

            
            var t = GetEntityTypeFromModel();
            var Rule = RuleFactory.GetDomainRule(t, client);

            if (Rule != null) /* dynamic */
                Rule.RunRulesOnModel(this, modelstate);
        }

        void IBaseViewModelRule.SetViewModelRules(dynamic RuleFactory, IClientInfo client, bool cleanState)
        {
            var t = GetEntityTypeFromModel();
            var Rule = RuleFactory ==null ?null :RuleFactory.GetDomainRule(t, client);

            if (Rule != null) /* dynamic */
                Rule.SetViewModelRules(this);
            //if(cleanState)
            //    this.SetCleanViewModel();
        }

        private Type GetEntityTypeFromModel()
        {
            var type = GetBaseType(this.GetType())
                       .BaseType
                       .GetGenericArguments()
                       .FirstOrDefault();

            return type;
        }
        private string GetEntityNameFromModel()
        {
             var type = GetBaseType(this.GetType())
                        .BaseType
                        .GetGenericArguments()
                        .FirstOrDefault();
            
            return type.Name;
        }

        private Type GetBaseType(Type t)
        {
                Type outType = t;
                do
                    if (outType.BaseType != null && outType.BaseType != typeof(Object))
                    { 
                        outType = outType.BaseType;

                    if (outType.GetGenericArguments()
                        .Any(w => typeof(IBaseEntity).IsAssignableFrom(w)))
                            break;
                        
                    }
                    else
                        break;
                while (true);

            return outType; 
        }
    }
}
