using Repos.DomainModel.Interface.Interfaces;

namespace ReposDomain.Domain
{
    public class Role
        : BaseEntity<Role>, IBaseEntity
    {
      
        public string RoleName { protected set; get; }
        
    }
}
