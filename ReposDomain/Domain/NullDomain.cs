using Repos.DomainModel.Interface.Atrributes.DomainAttributes;
using Repos.DomainModel.Interface.Interfaces;

namespace ReposDomain.Domain
{
    [DomainNoBindAttribute]
    public sealed class NullDomain
         : BaseEntity<NullDomain>, IBaseEntity
    {
     
    }
}
