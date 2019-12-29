using Repos.DomainModel.Interface;
using Repos.DomainModel.Interface.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReposDomain.Domain
{
    public class ClientRule
         : BaseEntity<ClientRule>, IBaseEntity
    {
        
        [ForeignKey("Rule")]
        public int RulesId { set; get; }
        public Rule Rule {set; get;}
    }
}
