using Repos.DomainModel.Interface;
using ReposDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposDomain.DomainMaps
{
    class WebApiControllerMap
    : ReposEntityTypeConfiguration<WebApiController>

    {
        public WebApiControllerMap()
        {


            this.ToTable("webapicontrollers");
            this.HasKey(m => m.Id);

            this.Property(m => m.Id)
            .HasColumnName("controllerid");
        }
    }
}