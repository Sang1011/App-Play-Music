using MusicPlayerApp.DAL.Entities;
using MusicPlayerApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.BLL.Services
{
    public class UserServices
    {
        private UserRepositories _repo = new();

        public List<User> GetList()
        {
            return _repo.GetAll();
        }

        public User? Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
    }
}
