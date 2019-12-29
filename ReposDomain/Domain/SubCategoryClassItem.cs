using Repos.DomainModel.Interface.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ReposDomain.Domain
{
    public class SubCategoryClassItem
         : BaseEntity<SubCategoryClassItem>, IBaseEntity
    {
        protected SubCategoryClassItem() {
           Id = default(int);
        }
              
        [Required]
        public int SubCategoryId { set; get; }

        public string SubCategoryClassItemName { set; get; }

        public virtual SubCategory SubCategory { get; set; }
        
    }
}
