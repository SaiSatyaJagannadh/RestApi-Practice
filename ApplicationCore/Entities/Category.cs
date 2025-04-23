using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Category
{
    public int Id { get; set; }
    [Required][Column(TypeName = "varchar(30)")]
    public string CategoryName { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string Description { get; set; }
    
    public ICollection<Product> Products { get; set; }
}