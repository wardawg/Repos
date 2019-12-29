using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public partial class CategoryMap : ReposEntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Categories");
            this.HasKey(m => m.Id);

            this.Property(m => m.Id)
            .HasColumnName("CategoryId");
         
        }
    }
}
