using Abp.Domain.Entities;
using Acme.SimpleTaskSystem.Base;
using Acme.SimpleTaskSystem.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.SimpleTaskSystem.Users
{
    [Table("Users")]
    public class User:Entity
    {
        [Required]
        public string FirstName { get; set;}
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public User() { }
        public User(string firstName, string lastName, string userName, string password):this()
        {
            FirstName = firstName;
            LastName = lastName; ;
            Username = userName;
            Password = password;
        }

    }
}
