using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public partial class CustomerMap : ReposEntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("Customers");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
            .HasColumnName("CustomerId");
        

        }
    }
}
