using Repos.DomainModel.Interface.Custom.Types;
using Repos.DomainModel.Interface.Interfaces;
using System.Web.Mvc;

namespace ReposDomainRules
{

    public interface IServiceEntityRule
      {
        void RunRules(IBaseEntity Entity    
                 , EntityRules Entities
                 , ModelStateDictionary modelState);

        void RunRules(IBaseEntity Entity
                      , ModelStateDictionary modelState
                     );
    }
    
    public interface IServiceEntityRule<T> : IServiceEntityRule

    {
     
    
    }
}
