using Repos.DomainModel.Interface.Interfaces;

namespace ReposDomain.Domain
{
    public class Rule
        : BaseEntity<Rule>, IBaseEntity
    {
        public string RuleName { protected set; get; }
        public int RuleGrpId { protected set; get; }
        
    }
}
