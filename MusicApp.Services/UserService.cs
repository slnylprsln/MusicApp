using MusicApp.Entities;
using MusicApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public class UserService : IUserService
    {
        private List<User> users;

        public UserService()
        {
            users = new List<User>() {
                 new() { NameSurname = "Selenay Alparslan", Email = "test1@gmail.com", Password = "1234Abcd!", Role = Role.Admin, Username = "selenaya" },
                 new() { NameSurname = "Türkay Ürkmez", Email = "test2@gmail.com", Password = "1234Abcd!", Role = Role.Admin, Username = "turkayu" },
                 new() { NameSurname = "İsim Soyisim", Email = "test3@gmail.com", Password = "1234Abcd!", Role = Role.Listener, Username = "isims" },
            };
        }

        public User? ValidateUser(string username, string password)
        {
            return users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
