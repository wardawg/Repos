using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public partial class ClientMap : ReposEntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            this.ToTable("Clients");
            this.HasKey(m => m.Id);

            this.Property(m => m.Id)
            .HasColumnName("ClientId");
         
        }
    }
}
