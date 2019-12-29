using Repos.DomainModel.Interface.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReposDomain.Domain
{
    public partial class SubCategoryItem
          : BaseEntity<SubCategoryItem>, IBaseEntity
    {
        protected SubCategoryItem(){
            AltId = ObjectId();
        }


        [NotMapped]
        public override int Id { get; protected set; }

        [Required]
        [Column]
        [Key]
        public string AltId { set; get; }

        [Required]
        public int SubCategoryId { set; get; }

        public string SubCategoryItemName { set; get; }

        public virtual SubCategory SubCategory { get; set; }
           

    }
}
