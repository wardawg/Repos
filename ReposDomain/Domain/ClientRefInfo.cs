using Repos.DomainModel.Interface.Interfaces;

namespace ReposDomain.Domain
{
    public partial class ClientRefInfo
        : BaseEntity<ClientRefInfo>, IBaseEntity
    {
         
         public string AssmPrefix { get; set; }
         public string ExtClientId { get; internal set; }
         public string ClientKey { get; set; }
      //   public Client Client { set; get; }
    }
}
