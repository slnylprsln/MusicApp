using MusicApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DataTransferObjects.Requests.User
{
    public class CreateNewUserRequest
    {
        public string NameSurname { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Username { get; set; }
    }
}
