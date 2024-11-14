using MusicPlayerApp.DAL.Entities;
using MusicPlayerApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.BLL.Services
{
    public class PlaylistServices
    {
        private PlaylistRepository _repo = new();

        public List<Playlist> GetPlaylist(int userID)
        {
            return _repo.GetPlaylistByUser(userID);
        }

        public Playlist? GetOne(int playlistID)
        {
            return _repo.GetPlaylistById(playlistID);
        }

        public int AddSongToPlaylist(int playlistID, Song song) 
        {
            return _repo.AddSongToUserPlaylist(playlistID, song);
        }

        public void AddPlaylist(Playlist playlist)
        {
            _repo.Add(playlist);
        }

        public bool RemoveSongFromPlaylist(int playlistID, Song song)
        {
            return _repo.RemoveSong(playlistID, song);
        }
    }
}
