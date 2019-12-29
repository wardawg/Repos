using ReposData.Repository;
using ReposDomain.Domain;
using ReposServiceConfigurations.ServiceTypes.Base;
using ReposServiceConfigures.ServiceTypes.Handlers;
using System;
using System.Linq;

namespace ReposDomain.Handlers.Handlers
{
    public class ClientHandler
              : ServiceGenericHandler<Client>
          , IClientHandler
    {
        private readonly IRepository<Client> _Repos;
        public ClientHandler(IRepository<Client> Repos
                                    , ICacheService cache)
            :base(Repos,cache)
        {
            _Repos = Repos;
        }

        IQueryable<Client> IClientHandler.Get()
        {
            return base.Get().AsQueryable();
        }
}
}
