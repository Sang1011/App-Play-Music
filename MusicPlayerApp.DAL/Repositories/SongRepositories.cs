using Microsoft.EntityFrameworkCore;
using MusicPlayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.DAL.Repositories
{
    public class SongRepositories
    {
        private MusicAppContext _context;

        public List<Song> GetAll()
        {
            _context = new MusicAppContext();
            return _context.Songs.Include(s => s.User).Include(s => s.Genre).ToList();
        }

        public void Add(Song x)
        {
            _context = new();
            _context.Songs.Add(x);
            _context.SaveChanges();
        }

        public void Update(Song x) 
        {
            _context = new();
            _context.Songs.Update(x);
            _context.SaveChanges();
        }

        public void Delete(Song x) 
        {
            _context = new();
            _context.Songs.Remove(x);
            _context.SaveChanges();
        }
    }
}
