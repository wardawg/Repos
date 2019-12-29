using Repos.DomainModel.Interface.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ReposDomain.Domain
{
    public class SubCategoryType 
        : BaseEntity<SubCategoryType>, IBaseEntity 
    {

        [Required]
        public int SubCategoryId { get; set; }

        public string SubCategoryTypeName { get; set; }

        public virtual SubCategory SubCategory { get; set; }
               
    }
}

 