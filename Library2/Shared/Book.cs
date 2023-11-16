using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library2.Shared;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int inventory_number { get; set; }

    public string title { get; set; }

    public string author { get; set; }

    public string publisher { get; set; }
    
    
}