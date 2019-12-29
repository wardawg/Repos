using Repos.DomainModel.Interface.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Repos.Common.Edits.Validation
{

    [MetadataType(typeof(SubCategoryMetaData))]
    public partial class SubCategoryP
        : ReposDomain.Domain.SubCategory
        , IBaseEntity
    {
      
    }


    public class SubCategoryMetaData
    {
        // Apply RequiredAttribute
        [Required(ErrorMessage = "Title is required.")]
        public object SubCategoryId;


    }
}
