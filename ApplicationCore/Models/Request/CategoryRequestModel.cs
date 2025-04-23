using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.Request;

public class CategoryRequestModel
{
    [Required(ErrorMessage = "Name is required")]
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
}