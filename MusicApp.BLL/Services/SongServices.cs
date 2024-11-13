using Microsoft.EntityFrameworkCore;
using MusicApp.DAL.Entities;
using MusicApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.BLL.Services
{
    public class SongServices
    {
        private SongRepositories _repo = new();

        public List<Song> GetList()
        {
            return _repo.GetAll();
        }

        public List<Song> GetAllListSongsWithUserID(int userID)
        {
            return _repo.GetAllListSongsWithUserID(userID);
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
