using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library2.Shared;

public class Reader
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Reader_number { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }
    
    [Required]
    [Range(typeof(DateTime), "1900-01-01","3000-12-31")]
    public DateTime? BirthDate { get; set; }
    

}