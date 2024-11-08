using System;
using System.Collections.Generic;

namespace MusicPlayerApp.DAL.Entities;

public partial class Playlist
{
    public int PlaylistId { get; set; }

    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
