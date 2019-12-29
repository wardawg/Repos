using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReposDomain.Domain
{

    public partial class SubCategory
        : BaseEntity<SubCategory>, IBaseEntity
     
    {
               

        [Required]
        //public int CategoryId { get; set; }
        public DomainEntityTypeInt CategoryId { get; set; } = new DomainEntityTypeInt();

        [Required]
        //public int CategoryTypeId { set; get; }
        public DomainEntityTypeInt CategoryTypeId { set; get; } = new DomainEntityTypeInt();

        public DomainEntityTypeString SubCategoryName { get; set; }  = new DomainEntityTypeString();

        public virtual ICollection<SubCategoryType> SubCategoryTypes { get; set; } = new List<SubCategoryType>();
        public virtual ICollection<SubCategoryItem> SubCategoryItems { get; set; } = new List<SubCategoryItem>();
        public virtual ICollection<SubCategoryClassItem> SubCategoryClassItems { get; set; } = new List<SubCategoryClassItem>();
        public virtual ICollection<SubCategoryLevel> SubCategoryUsersLevels { get; set; } = new List<SubCategoryLevel>();


    }
        
}