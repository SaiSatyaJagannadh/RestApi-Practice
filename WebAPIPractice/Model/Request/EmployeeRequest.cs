using System.ComponentModel.DataAnnotations;

namespace WebAPIPractice.Model.Request;

public class EmployeeRequest
{
    [Required]
    public string FIrstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string phoneNumber { get; set; }
    
    public decimal salary { get; set; }
}