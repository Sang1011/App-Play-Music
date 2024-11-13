using System;
using System.Collections.Generic;

namespace MusicApp.DAL.Entities;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
