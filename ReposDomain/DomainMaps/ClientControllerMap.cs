using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    //ClientControlleMap
    public class ClientControllerMap
        : ReposEntityTypeConfiguration<ClientController>
      
    {
        public ClientControllerMap()
        {

            this.ToTable("ClientControllers");
            this.HasKey(m => m.Id);

            this.Property(m => m.Id)
            .HasColumnName("ClientId");
        }
    }
}
