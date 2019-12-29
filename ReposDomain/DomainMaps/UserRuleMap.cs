using Repos.DomainModel.Interface;
using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public class UserRuleMap : ReposEntityTypeConfiguration<UserRule>
    {
        public UserRuleMap()
        {
            this.ToTable("UserRules");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
            .HasColumnName("UserId");
         
        }
    }
}
