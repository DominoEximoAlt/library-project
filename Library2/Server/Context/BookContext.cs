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
            entity.HasOne(e => e.Rental).WithOne(r => r.Book).HasForeignKey<Rental>(b =>b.InventoryNumber).OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.ToTable("ReaderList");
            entity.Property(e => e.Reader_number).HasColumnName("identity");
            entity.HasKey(b => b.Reader_number);
            entity.HasOne(e => e.Rental).WithOne(r => r.Reader).HasForeignKey<Rental>(b =>b.ReaderNumber).OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.ToTable("RentalList");
            
            entity.Property(e => e.RentalId).HasColumnName("id");
            entity.HasKey(e => e.RentalId);
        });
    }
}