using Repos.Mapper;
using ReposCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCoreModel;

namespace WebApplicationCore
{
    public class RdStartTask : IStartupTask
    {
        public int Order
        {
            get
            {
                return 2;
            }
        }
        public void Execute()
        {
    //        AutoMapperConfiguration.Init<IDomain, IModelView>();
            //    var s = new string( "ileie" );
        }
    }
}
