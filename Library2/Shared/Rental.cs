using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library2.Shared;

public class Rental
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RentalId { get; set; } 
    [Required]
    public int ReaderNumber { get; set; } 
    [Required]
    public int InventoryNumber { get; set; }

    public Reader Reader;

    public Book Book;
    
    
    [Required]
    public DateTime RentDate { get; set; }
    
    [Required]
    public DateTime ReturnDate { get; set; }
}