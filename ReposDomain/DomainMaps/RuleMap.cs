using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public partial class RuleMap : ReposEntityTypeConfiguration<Rule>
    {
        public RuleMap()
        {
            this.ToTable("Rules");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
            .HasColumnName("RuleId");
         

        }
    }
}
