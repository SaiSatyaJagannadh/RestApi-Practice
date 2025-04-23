using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIPractice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategory());
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryRequestModel model)
        {
            return Ok(_categoryService.AddCategory(model));
            
        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryRequestModel model, int id)
        {
            return Ok(_categoryService.UpdateCategory(model, id));
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            return Ok(_categoryService.DeleteCategory(id));
        }
        
        [HttpGet]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(_categoryService.GetCategoryById(id));
        }
    }
}
