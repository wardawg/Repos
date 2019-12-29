using Repos.DomainModel.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposDomain.Domain
{
    public class SubCategoryUserLevel
        : BaseEntity<SubCategoryUserLevel>, IBaseEntity
    {
        public int SubCategoryLevelId { get; set; }
        public int ClientId { get; set; }

    }
}
