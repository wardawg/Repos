using ReposData.Repository;
using ReposDomain.Domain;

 using ReposServiceConfigurations.ServiceTypes.Base;
using ReposServiceConfigurations.ServiceTypes.Edits;
using ReposServiceConfigurations.ServiceTypes.Rules;

namespace ReposServices.ClientsServices
{
    public class ClientsService
      : BaseService<Client>,  IClientsService
       {
      
      
        public ClientsService(IRepository<Client> clientRepository
                                , ICacheService Cache
                                , IDomainEdit Edits
                                , IRule RulesFactory)  
            :base(clientRepository, Cache,null, RulesFactory)
        {

        }



    }
}
