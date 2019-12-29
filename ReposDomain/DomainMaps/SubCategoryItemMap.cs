using Repos.DomainModel.Interface;
using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public partial class SubCategoryItemMap : ReposEntityTypeConfiguration<SubCategoryItem>
    {
        public SubCategoryItemMap()
        {
            this.ToTable("SubCategoryItems");
            this.HasKey(m => m.AltId);
            this.Property(m => m.AltId)
            .HasColumnName("SubCategoryItemId");
        }
    }
}
