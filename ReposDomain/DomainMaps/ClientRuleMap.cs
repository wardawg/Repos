using ReposDomain.Domain;
using Repos.DomainModel.Interface;

namespace ReposDomain.DomainMaps
{
    public partial class ClientRuleMap : ReposEntityTypeConfiguration<ClientRule>
    {
        public ClientRuleMap()
        {
            this.ToTable("ClientRules");
            this.HasKey(m => m.Id);

            this.Property(m => m.Id)
            .HasColumnName("ClientRuleId");
         
        }
    }
}
