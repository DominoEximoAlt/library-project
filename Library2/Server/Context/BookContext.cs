using System.ComponentModel.DataAnnotations.Schema;
using Library2.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library2.Server.Context;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions options) 
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    public virtual DbSet<Rental> Rents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("BookList");
            entity.Property(e => e.Inventory_number).HasColumnName("identity");
            entity.HasKey(b => b.Inventory_number);
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.ToTable("ReaderList");
            entity.Property(e => e.Reader_number).HasColumnName("identity");
            entity.HasKey(b => b.Reader_number);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.ToTable("RentalList");
            entity.HasOne(e => e.Reader).WithOne().HasForeignKey<Reader>(r => r.Reader_number).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(e => e.Book).WithOne().HasForeignKey<Book>(r => r.Inventory_number).OnDelete(DeleteBehavior.NoAction);
            entity.Property(e => e.RentalId).HasColumnName("identity");
            entity.HasKey(r => r.RentalId);
        });
    }
}