using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Product
{
    public int Id { get; set; }
    [Required][Column(TypeName = "varchar(30)")]
    public string ProductName { get; set; }
    [Required]
    public decimal UnitPrice { get; set; }
    [Required]
    public int Quantity { get; set; }
    public decimal Discount { get; set; }
    
    public int CategoryId { get; set; }//no need because of belowone but we create 
    //navigation property will create a foreign key column(CategoryId)
    
    public Category Category { get; set; }
}
