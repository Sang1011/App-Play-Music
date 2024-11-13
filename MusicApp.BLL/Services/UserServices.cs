using MusicApp.DAL.Entities;
using MusicApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.BLL.Services
{
    public class UserServices
    {
        private MusicAppContext _context;

        public List<User> GetAll()
        {
            _context = new MusicAppContext();
            return _context.Users.ToList();
        }
    }
}
