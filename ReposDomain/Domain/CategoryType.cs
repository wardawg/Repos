using System.ComponentModel.DataAnnotations;
using Repos.DomainModel.Interface;
using Repos.DomainModel.Interface.Interfaces;
namespace ReposDomain.Domain
{
    public class CategoryType
         : BaseEntity<CategoryType>, IBaseEntity
    {
               
        
        [Required]
        public int CategoryId { set; get; }

        public string CategoryTypeName { set; get; }
    }
}
