using Repos.DomainModel.Interface;
using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public partial class SubCategoryTypeMap : ReposEntityTypeConfiguration<SubCategoryType>
    {
        public SubCategoryTypeMap()
        {
            this.ToTable("SubCategoryTypes");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
            .HasColumnName("SubCategoryTypeId");
         


        }
    }
}
