using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Library2.Shared;


public class Rental
{
    
    public int Reader_number { get; set; }
    
    public int Inventory_number { get; set; }

    public Book RentedBook;

    public Reader Reader;
    
    [Required]
    public DateTime RentDate { get; set; }
    
    [Required]
    public DateTime ReturnDate { get; set; }
}