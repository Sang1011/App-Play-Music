using MusicApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DAL.Repositories
{
    public class GenreRepositories
    {
        private MusicAppContext _context;
        public List<Genre> GetAll()
        {
            _context = new MusicAppContext();
            return _context.Genres.ToList();
        }
    }
}
