using Repos.DomainModel.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposDomain.Domain
{
    public class SubCategoryLevel
        : BaseEntity<SubCategoryLevel>, IBaseEntity
    {
        public int SubCategoryId { get; set; }
        public string LevelName { get; set; }

    }
}
