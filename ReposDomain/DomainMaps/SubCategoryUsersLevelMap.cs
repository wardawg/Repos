using Repos.DomainModel.Interface;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public class SubCategoryUsersLevelMap
     : ReposEntityTypeConfiguration<SubCategoryUserLevel>
    {
        public SubCategoryUsersLevelMap()
        {
            this.ToTable("SubCategoryUsersLevels");

            //.HasMany(hm => hm.Roles);
            this.HasKey(q =>
                            new {
                                q.Id
                                ,q.SubCategoryLevelId
                            }
                       );

            this.Property(m => m.Id)
               .HasColumnName("UserId");

        }
    }   
}
