using MusicApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services.Interfaces
{
    public interface IUserService
    {
        User? ValidateUser(string username, string password);
    }
}
