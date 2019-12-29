using Repos.DomainModel.Interface.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReposDomain.Domain
{
    public class UserRule
        : BaseEntity<UserRule>, IBaseEntity
    {
        [ForeignKey("Rule")]
        public int RuleId { internal set; get; }
        public Rule Rule {  get; internal set; }
              
    }
}
