using MusicPlayerApp.DAL.Entities;
using MusicPlayerApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.BLL.Services
{
    public class SongServices
    {
        private SongRepositories _repo = new();

        public List<Song> GetList()
        {
            return _repo.GetAll();
        }

        public void AddSong(Song x)
        {
            _repo.Add(x);
        }

        public void RemoveSong(Song x) 
        {
            _repo.Delete(x);
        }

        public void UpdateSong(Song x)
        {
            _repo.Update(x);
        }
    }
}
