using Repos.DomainModel.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoUnitTest.Entities
{

    public interface ITestReposAttribute : IGenericHandler { }
    public class TestReposAttribute
        : BaseEntity<TestReposAttribute>, IBaseEntity
    {
        public new int Id { set; get; }
        public string AttributeName { set; get; }
    }
}
