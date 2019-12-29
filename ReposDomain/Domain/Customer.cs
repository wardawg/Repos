using Repos.DomainModel.Interface.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReposDomain.Domain
{

    public class Customer 
        : BaseEntity<Customer> ,IBaseEntity

    {
        protected Customer() {
            Id = default(int);
        }

     
        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
              
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
              
        
    }
}
