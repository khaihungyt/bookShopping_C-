using System;
using System.Collections.Generic;

namespace PRN212_Assignment.Models;

public partial class Genre
{
    public string GenreId { get; set; } = null!;

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
