using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Entities
{
    public class User : IEntity
    {
        public int Id { get; set;}
        public string NameSurname { get; set;}
        public string? Email { get; set;}
        public string Password { get; set;}
        public Role Role { get; set;}
        [Required]
        public string Username { get; set;}
    }

    public enum Role
    {
        Admin,
        Listener
    }
}
