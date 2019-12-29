using Repos.DomainModel.Interface;
using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public partial class SubCategoryClassItemMap : ReposEntityTypeConfiguration<SubCategoryClassItem>
    {
        public SubCategoryClassItemMap()
        {
            this.ToTable("SubCategoryClassItems");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
            .HasColumnName("SubCategoryClassItemId");
         

        }
    }
}
