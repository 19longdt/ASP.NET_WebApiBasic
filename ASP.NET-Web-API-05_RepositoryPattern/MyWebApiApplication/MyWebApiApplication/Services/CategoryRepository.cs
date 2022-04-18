using MyWebApiApplication.DataDB;
using MyWebApiApplication.DTO;
using MyWebApiApplication.Models;
using MyWebApiApplication.MyDBC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyDBContext _context;

        public CategoryRepository(MyDBContext myDBContext)
        {
            _context = myDBContext;
        }

        public CategoryDto addCategory(CategoryModel categoryModel)
        {
            var category = new Category
            {
                categoryName = categoryModel.categoryName
            };

            _context.Add(category);
            _context.SaveChanges();

            return new CategoryDto
            {
                categoryId = category.categoryId,
                categoryName = category.categoryName
            };
        }

        public void deleteCategory(int id)
        {
            var category = _context.categoies.SingleOrDefault(cate => cate.categoryId == id);

            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }
        }
        public List<CategoryDto> getAllCategory()
        {
            var categories = _context.categoies.Select(cat => new CategoryDto
            {
                categoryId = cat.categoryId,
                categoryName = cat.categoryName
            });
            return categories.ToList();
        }

        public CategoryDto getById(int id)
        {
            var category = _context.categoies.SingleOrDefault(cate => cate.categoryId == id);

            if (category != null)
            {
                return new CategoryDto
                {
                    categoryId = category.categoryId,
                    categoryName = category.categoryName
                };
            }
            else
            {
                return null;
            }
        }

        public void updateCategory(CategoryDto category)
        {
            var cate = _context.categoies.SingleOrDefault(cate => cate.categoryId == category.categoryId);
            cate.categoryName = category.categoryName;
            _context.SaveChanges();
        }
    }
}
