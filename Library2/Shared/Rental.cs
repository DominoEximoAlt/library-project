using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Library2.Shared;

public class Rental
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RentalId { get; set; } 
    public int ReaderNumber { get; set; } 
    
    public int InventoryNumber { get; set; }

    public Reader Reader;

    public Book Book;
    
    
    [Required]
    [Today]
    public DateTime RentDate { get; set; }
    
    [Required]
    [FromNow]
    public DateTime ReturnDate { get; set; }
}