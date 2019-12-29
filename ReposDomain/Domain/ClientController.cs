using Repos.DomainModel.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposDomain.Domain
{
   public class ClientController
        : BaseEntity<ClientController>, IBaseEntity
    {
        public int ControllerId { set; get; }
    }
}
