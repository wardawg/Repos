using Repos.DomainModel.Interface.DomainComplexTypes;
using Repos.DomainModel.Interface.DomainViewModels;
using Repos.DomainModel.Interface.Interfaces;
//using ReposAdmin.Models.Validation.Repos.Model.Validation;
using ReposDomain.Domain;

namespace Repos.Models.SubCategories


{

    public partial class SubCategoryModel
        : ViewModel<SubCategory>
        , IDomainViewModel<SubCategory>
        , IModelRule


    {
        //[RequiredValidation("Sub Cat Required")]
        public DomainEntityTypeString SubCategoryName { get; set; }
        public DomainEntityTypeInt CategoryId { get; set; } = new DomainEntityTypeInt();
        public DomainEntityTypeInt CategoryTypeId { get; set; } = new DomainEntityTypeInt();

        //  [DisplayName("Sub Category Name")]
        // public string SubCategoryName { get; set; }

        //  public DomainEntityTypeString SubCategoryName { get; set; }

        //[Required]
        //   [Range(1, int.MaxValue, ErrorMessage = "Category Is Not Selected")]
        //public int CategoryId { get; set; }
        // public DomainEntityTypeInt CategoryId  { get; set;} = new DomainEntityTypeInt();

        // [Range(1, int.MaxValue, ErrorMessage = "Category Type Is Not Selected")]

        //[Required]
        //public DomainEntityTypeInt CategoryTypeId { get; set; } = new DomainEntityTypeInt();
            

    }
}
