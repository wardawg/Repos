using Repos.DomainModel.Interface.Interfaces;
using ReposData.Repository;
using ReposServiceConfigurations.ServiceTypes.Edits;
using ReposServiceConfigurations.ServiceTypes.Rules;
using ReposServiceConfigurations.ServiceTypes.Base;

namespace RepoUnitTest.Services
{
    public class TestServices<T>
        : BaseService<T> where T : BaseEntity<T>
    {
        public TestServices(IRepository<T> Repos
            , IDomainEdit Edits
            , IRule RulesFactory) 
             : base(Repos,null, Edits, RulesFactory)
        {
        }
    }
}
