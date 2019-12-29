using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public class UserRoleMap : ReposEntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRoles");
            
                //.HasMany(hm => hm.Roles);
            this.HasKey(q =>
                            new {
                                    q.Id
                                    ,q.RoleId
                                }
                       );

            this.Property(m => m.Id)
               .HasColumnName("UserId");
         
        }
    }
}
