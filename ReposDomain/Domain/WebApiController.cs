using Repos.DomainModel.Interface.Interfaces;

namespace ReposDomain.Domain
{
    public class WebApiController
            : BaseEntity<WebApiController>
            , IBaseEntity
    {
        public int? parentid { set; get; }
        public string controllername { get; set; }
        public int? version { get; set; }
        
    }
}
