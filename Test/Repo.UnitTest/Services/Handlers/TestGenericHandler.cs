using Moq;
using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.Interfaces;
using ReposData.Repository;
using RepoUnitTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitTest.Services.Handler
{

    public sealed class TestGenericHandler
        : IServiceGenericHandler
    {

        public IQueryable GetData<Entity>()
            where Entity : IGenericHandler
        {
            return new List<TestReposAttribute>()
            {
                new Mock<TestReposAttribute>().Object
               ,new Mock<TestReposAttribute>().Object
            }.AsQueryable();
                        
        }
    }
    
}
