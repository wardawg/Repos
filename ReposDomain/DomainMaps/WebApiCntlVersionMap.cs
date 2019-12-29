using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public class WebApiCntlVersionMap
        : ReposEntityTypeConfiguration<WebApiCntlVersion>
       
    {
        public WebApiCntlVersionMap()
        {

            this.ToTable("WebApiCntlVersions");
            this.HasKey(m => m.Id);

            this.Property(m => m.Id)
            .HasColumnName("controllerid");
        }
    }
}
