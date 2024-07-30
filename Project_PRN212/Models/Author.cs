using System;
using System.Collections.Generic;

namespace PRN212_Assignment.Models;

public partial class Author
{
    public string AuthorId { get; set; } = null!;

    public string AuthorName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
