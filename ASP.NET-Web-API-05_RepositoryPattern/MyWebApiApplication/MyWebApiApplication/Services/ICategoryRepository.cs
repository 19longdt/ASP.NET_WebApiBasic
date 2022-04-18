using MyWebApiApplication.DataDB;
using MyWebApiApplication.DTO;
using MyWebApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.Services
{
    public interface ICategoryRepository
    {
        List<CategoryDto> getAllCategory();
        CategoryDto getById(int id);
        CategoryDto addCategory(CategoryModel categoryModel);
        void updateCategory(CategoryDto category);
        void deleteCategory(int id);
    }
}
