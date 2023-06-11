using MusicApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DataTransferObjects.Responses.User
{
    public class UserDisplayResponse
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Username { get; set; }
    }
}
