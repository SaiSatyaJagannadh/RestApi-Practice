using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using AutoMapper;

namespace Infrastructure.Services;

public class CategoryService: ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper  mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public int AddCategory(CategoryRequestModel model)
    {
        // Category c = new Category();
        // c.CategoryName = model.CategoryName;
        // c.Description = model.CategoryDescription;
        
        //we can do the above lines with this one line 
        Category category = _mapper.Map<Category>(model);
        return _categoryRepository.Insert(category);
        
    }
    

    public int UpdateCategory(CategoryRequestModel model, int id)
    {
        Category c = new Category();
        c.CategoryName = model.CategoryName;
        c.Id = id;
        c.Description = model.CategoryDescription;
        return _categoryRepository.Update(c);
    }

    public int DeleteCategory(int id)
    {
return _categoryRepository.Delete(id);
    
    }

    public List<CategoryResponseModel> GetAllCategory()
    {
        List<CategoryResponseModel> categories = new List<CategoryResponseModel>();
        var  categoriesList = _categoryRepository.GetAll();
        foreach (var category in categoriesList)
        {
            CategoryResponseModel c = new CategoryResponseModel();
            c.Id = category.Id;
            c.Name = category.CategoryName;
            c.Description = category.Description;
            categories.Add(c);
        }

       return categories;
    }

    public CategoryResponseModel GetCategoryById(int id)
    {
        var categories = _categoryRepository.GetById(id);
        CategoryResponseModel categoryResponse = new CategoryResponseModel();
        categoryResponse.Description = categories.Description;
        categoryResponse.Id = categories.Id;
        categoryResponse.Name = categories.CategoryName;
        return categoryResponse;
    }
}