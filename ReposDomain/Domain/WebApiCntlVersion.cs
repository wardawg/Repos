using Repos.DomainModel.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposDomain.Domain
{
    public class WebApiCntlVersion
           : BaseEntity<WebApiCntlVersion>
       
    {

    public int? version { get; set; }
    public DateTime? ActiveDate { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public string Expired { get; set; }

}
}
