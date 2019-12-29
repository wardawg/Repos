using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public partial class RoleMap : ReposEntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable("Roles");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
                .HasColumnName("RoleId");
                
        }
    }
}
