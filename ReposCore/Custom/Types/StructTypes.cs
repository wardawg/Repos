using System.Collections.Generic;

namespace ReposCore.Custom.Types
{
    public struct EntityRules
    {
        public IDictionary<string, dynamic> Rules;
        public EntityRules(object Initializer)
        {
            //   var c = default(int);
          //  var c = Initializer;

            this.Rules = new Dictionary<string, dynamic>();
        }

    }

}
