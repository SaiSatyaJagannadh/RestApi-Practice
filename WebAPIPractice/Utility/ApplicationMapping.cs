using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace WebAPIPractice.Utility;

public class ApplicationMapping:Profile
{
    public ApplicationMapping()
    {
        CreateMap<Category, CategoryRequestModel>().ReverseMap();
        CreateMap<Category, CategoryResponseModel>().ReverseMap();
    }
}