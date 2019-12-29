using Repos.DomainModel.Interface.Interfaces;
using Repos.DomainModel.Interface.DomainComplexTypes;

namespace ReposDomain.Domain
{
    public class RuleType
        : BaseEntity<RuleType>, IBaseEntity
    {
       public DomainEntityTypeString RuleTypeName { get; set; }
    }
}
