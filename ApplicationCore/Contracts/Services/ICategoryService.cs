using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.Contracts.Services;

public interface ICategoryService
{
int AddCategory(CategoryRequestModel model);
int UpdateCategory(CategoryRequestModel model, int id);
int DeleteCategory(int id);
List<CategoryResponseModel> GetAllCategory();
CategoryResponseModel GetCategoryById(int id);

}