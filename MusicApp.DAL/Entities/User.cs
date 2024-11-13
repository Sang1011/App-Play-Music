using System;
using System.Collections.Generic;

namespace MusicApp.DAL.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? CreatedDate { get; set; }
    public string? Image { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
