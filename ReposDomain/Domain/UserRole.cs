using Repos.DomainModel.Interface.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReposDomain.Domain
{
    public class UserRole
        : BaseEntity<UserRole>, IBaseEntity
    {

        [Column]
        // [ForeignKey("Id")]
        // public virtual User User{ get; internal set; }
    //    public int UserId { get; internal set; }


        public int RoleId { get; internal set; }

        public Role Role { get; internal set; }
        public virtual User User { get; internal set; }
              
    }
}
