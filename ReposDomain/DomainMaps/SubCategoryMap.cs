using Repos.DomainModel.Interface;
using Repos.DomainModel.Interface.Interfaces;
using ReposDomain.Domain;

namespace ReposDomain.DomainMaps
{
    public partial class SubCategoryMap : ReposEntityTypeConfiguration<SubCategory>
    {

  //      public SubCategoryMap(string sTableNm, string sPrimKeyCol)
   //     : base(sTableNm, sPrimKeyCol){
    //    }

        public SubCategoryMap()
        {
                       
            this.ToTable("SubCategories");
            this.HasKey(m => m.Id);
            this.Property(m => m.Id)
            .HasColumnName("SubCategoryId");

            //this.MapToStoredProcedures(s => {
            //    s.Update(u => u.HasName("subcategory_update"));
            //    s.Delete(d => d.HasName("subcategory_delete"));
            //    s.Insert(i => i.HasName("subcategory_insert"));
            //});

    }
    }
}
