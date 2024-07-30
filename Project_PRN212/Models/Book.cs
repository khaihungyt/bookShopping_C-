using System;
using System.Collections.Generic;

namespace PRN212_Assignment.Models;

public partial class Book
{
    public string BookId { get; set; } = null!;

    public string BookName { get; set; } = null!;

    public int Quantity { get; set; }

    public double PriceInput { get; set; }

    public double PriceOutput { get; set; }

    public string GenreId { get; set; } = null!;

    public string AuthorId { get; set; } = null!;

    public string Image1 { get; set; } = null!;

    public string? Image2 { get; set; }

    public string? Image3 { get; set; }

    public string? Image4 { get; set; }

    public string Detailbook { get; set; } = null!;

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
