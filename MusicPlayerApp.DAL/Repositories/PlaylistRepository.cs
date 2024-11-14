using Microsoft.EntityFrameworkCore;
using MusicPlayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.DAL.Repositories
{
    public class PlaylistRepository
    {
        private MusicAppContext _context;

        public List<Playlist> GetPlaylistByUser(int userId)
        {
            _context = new();
            return _context.Playlists.Where(s => s.UserId == userId).ToList();
        }


        public Playlist? GetPlaylistById(int playlistID)
        {
            _context = new();
            return _context.Playlists
                .Include("Songs")
                .FirstOrDefault(p => p.PlaylistId == playlistID);
        }

        public int AddSongToUserPlaylist(int playlistID, Song songselected)
        {
            _context = new MusicAppContext();


            var playlist = _context.Playlists
            .Include(p => p.Songs)
            .FirstOrDefault(p => p.PlaylistId == playlistID);
            var song = _context.Songs.Find(songselected.SongId);

            if (song == null)
            {
                return -1;
            }

            if (!playlist.Songs.Contains(song))
            {
                playlist.Songs.Add(song);
                _context.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public bool RemoveSong(int playlistID, Song song)
        {
            _context = new();
            var playlist = _context.Playlists
            .Include(p => p.Songs) 
            .FirstOrDefault(p => p.PlaylistId == playlistID);

            if (playlist == null)
            {
                return false; 
            }

            var songToRemove = playlist.Songs.FirstOrDefault(s => s.SongId == song.SongId);
            if (songToRemove != null)
            {
                playlist.Songs.Remove(songToRemove);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public void Add(Playlist p)
        {
            _context = new();
            _context.Playlists.Add(p);
            _context.SaveChanges();
        }

    }
}
