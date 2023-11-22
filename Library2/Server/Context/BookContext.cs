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
            entity.HasOne(e => e.RentedBook)
                .WithOne()
                .HasForeignKey<Book>(e => e.Inventory_number)
                .IsRequired();
            entity.HasOne<Reader>(e => e.Reader).WithOne().HasForeignKey<Reader>(e => e.Reader_number);
            entity.ToTable("RentalList");
            entity.HasNoKey();
        });
    }
}