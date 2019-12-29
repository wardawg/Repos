using Repos.DomainModel.Interface;
using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.Interfaces;
using System.Collections.Generic;

namespace ReposDomain.Domain
{
    public class Client
            : BaseEntity<Client>, IBaseEntity
    {

        public DomainEntityTypeString ClientName {set; get;} = new DomainEntityTypeString();
        public DomainEntityTypeDateTime AddDte { set; get; } = new DomainEntityTypeDateTime();

      //  public virtual IReadOnlyCollection<ClientRefInfo> ClientRefInfo { get; set; }

    }
}
