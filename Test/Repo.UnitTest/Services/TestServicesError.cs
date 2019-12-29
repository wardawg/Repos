using ReposData.Repository;
using ReposServiceConfigurations.ServiceTypes.Base;
using ReposServiceConfigurations.ServiceTypes.Edits;
using ReposServiceConfigurations.ServiceTypes.Rules;
using RepoUnitTest.Entities;

namespace RepoUnitTest.Services
{
    public class TestServicesError
        : BaseService<TestEntityError>
    {
        public TestServicesError(IRepository<TestEntityError> Repos
           // , ICacheService cacheService
            , IDomainEdit Edits
            , IRule RulesFactory) 
             : base(Repos, null, Edits, RulesFactory)
        {
        }
    }
}
