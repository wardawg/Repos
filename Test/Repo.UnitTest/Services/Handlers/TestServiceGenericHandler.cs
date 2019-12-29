using Repos.DomainModel.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitTest.Services.Handler
{
    public class TestServiceGenericHandler
         : IGenericHandler
    {
        public IQueryable GetData<Entity>() where Entity : BaseEntity<Entity>
        {
            throw new NotImplementedException();
        }
    }
}
