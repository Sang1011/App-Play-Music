using System;
using System.Collections.Generic;

namespace MusicPlayerApp.DAL.Entities;

public partial class Song
{
    public int SongId { get; set; }

    public string Title { get; set; } = null!;

    public int UserId { get; set; }

    public int GenreId { get; set; }

    public TimeOnly Duration { get; set; }

    public string FilePath { get; set; } = null!;

    public DateOnly? ReleaseDate { get; set; }

    public string? Image { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}
