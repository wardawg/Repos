using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposDomain.Handlers.Handlers
{
   public interface IClientHandler
         : IServiceHandler
    {
        IQueryable<Client> Get();
    }
}
