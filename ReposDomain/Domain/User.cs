using Repos.DomainModel.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReposDomain.Domain
{
    public class User
        : BaseEntity<User>, IBaseEntity
    {

        public User(){
        }

        public User(int id,Client client)
        {
            Id = id;
        }

        [Required]
        public string UserName { set; get; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Column]
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }  
                
        public DateTime? AddDate { set; get; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
