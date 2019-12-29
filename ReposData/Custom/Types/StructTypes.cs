using Repos.DomainModel.Interface.Interfaces;
using System.Collections.Generic;

namespace ReposData.Custom.Types
{
    public struct EntityRules
    {
        public IDictionary<string, IBaseEntity> Rules;
        public EntityRules(IBaseEntity Initializer)
        {
            //   var c = default(int);
          //  var c = Initializer;

            this.Rules = new Dictionary<string, IBaseEntity>();
        }

    }

}
