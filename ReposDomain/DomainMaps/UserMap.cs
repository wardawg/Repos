using Repos.DomainModel.Interface;
using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;


namespace ReposDomain.DomainMaps
{
    public class UserMap : ReposEntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("Users");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
            .HasColumnName("UserId");
          
        }
    }
}
