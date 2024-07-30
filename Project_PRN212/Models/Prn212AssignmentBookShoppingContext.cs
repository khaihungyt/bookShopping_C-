using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PRN212_Assignment.Models;

public partial class Prn212AssignmentBookShoppingContext : DbContext
{
    public Prn212AssignmentBookShoppingContext()
    {
    }

    public Prn212AssignmentBookShoppingContext(DbContextOptions<Prn212AssignmentBookShoppingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build();
        var strConn = config["ConnectionStrings:MyDatabase"];
        optionsBuilder.UseSqlServer(strConn);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Authors__8E2731D98A22D214");

            entity.Property(e => e.AuthorId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("authorID");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .HasColumnName("authorName");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C227F7298391");

            entity.Property(e => e.BookId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BookID");
            entity.Property(e => e.AuthorId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("AuthorID");
            entity.Property(e => e.BookName)
                .HasMaxLength(255)
                .HasColumnName("bookName");
            entity.Property(e => e.Detailbook).HasColumnName("detailbook");
            entity.Property(e => e.GenreId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("GenreID");
            entity.Property(e => e.Image1).HasColumnName("image1");
            entity.Property(e => e.Image2).HasColumnName("image2");
            entity.Property(e => e.Image3).HasColumnName("image3");
            entity.Property(e => e.Image4).HasColumnName("image4");
            entity.Property(e => e.PriceInput).HasColumnName("priceInput");
            entity.Property(e => e.PriceOutput).HasColumnName("priceOutput");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books__AuthorID__160F4887");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books__GenreID__17036CC0");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__415B03D8375B1C3C");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cartID");
            entity.Property(e => e.BookId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bookID");
            entity.Property(e => e.BookImg)
                .HasMaxLength(255)
                .HasColumnName("bookImg");
            entity.Property(e => e.BookName)
                .HasMaxLength(255)
                .HasColumnName("bookName");
            entity.Property(e => e.BookPrice).HasColumnName("bookPrice");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userID");

            entity.HasOne(d => d.Book).WithMany(p => p.Carts)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__bookID__123EB7A3");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__userID__1332DBDC");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__C3B4DFAA733F8E1F");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CommentID");
            entity.Property(e => e.BookId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bookID");
            entity.Property(e => e.Comment1).HasColumnName("comment");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userID");

            entity.HasOne(d => d.Book).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__bookID__10566F31");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comment__userID__114A936A");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__3C5476A28C429062");

            entity.Property(e => e.GenreId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("genreID");
            entity.Property(e => e.GenreName)
                .HasMaxLength(255)
                .HasColumnName("genreName");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__0809337D2F59125C");

            entity.Property(e => e.OrderId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("orderID");
            entity.Property(e => e.BookId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bookID");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userID");

            entity.HasOne(d => d.Book).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__bookID__151B244E");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__userID__14270015");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CDF80B91C86");

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC5726CA32D28").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userID");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.UserAddress)
                .IsUnicode(false)
                .HasColumnName("userAddress");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserRole)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userRole");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("userpassword");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
