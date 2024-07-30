using System;
using System.Collections.Generic;

namespace PRN212_Assignment.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Userpassword { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserRole { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
