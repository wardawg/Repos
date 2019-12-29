using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
 
    public partial class ClientRefInfoMap : ReposEntityTypeConfiguration<ClientRefInfo>
    {
        public ClientRefInfoMap()
        {
            this.ToTable("ClientRefInfos");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
            .HasColumnName("ClientId");
        }
    }
}
