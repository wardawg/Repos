using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public class SubCategoryLevelMap
    : ReposEntityTypeConfiguration<SubCategoryLevel>
    {
        public SubCategoryLevelMap()
        {
            this.ToTable("SubCategoryLevels");

            //.HasMany(hm => hm.Roles);
            this.HasKey(q =>
                            new {
                                q.Id
                                    ,
                                q.SubCategoryId
                            }
                       );

            this.Property(m => m.Id)
               .HasColumnName("SubCategoryLevelId");

        }
    }
}
