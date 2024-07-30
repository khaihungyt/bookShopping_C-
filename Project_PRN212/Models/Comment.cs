using System;
using System.Collections.Generic;

namespace PRN212_Assignment.Models;

public partial class Comment
{
    public string CommentId { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Comment1 { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
