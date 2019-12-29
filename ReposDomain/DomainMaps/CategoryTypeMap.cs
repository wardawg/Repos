using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public partial class CategoryTypeMap : ReposEntityTypeConfiguration<CategoryType>
    {
        public CategoryTypeMap()
        {
            this.ToTable("CategoryTypes");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
            .HasColumnName("CategoryTypeId");
         
        }
    }
}
