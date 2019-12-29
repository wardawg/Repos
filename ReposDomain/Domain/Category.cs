using Repos.DomainModel.Interface.Interfaces;
using Repos.DomainModel.Interface.DomainComplexTypes;
using System.Collections.Generic;

namespace ReposDomain.Domain
{
    public class Category 
        : BaseEntity<Category>, IBaseEntity
    {
       
        public DomainEntityTypeString CategoryName { get; set; } = new DomainEntityTypeString();
        public DomainEntityTypeString Description { get; set; } = new DomainEntityTypeString();
        public virtual IReadOnlyCollection<CategoryType> CategoryTypes { get; set; }

    }
}
