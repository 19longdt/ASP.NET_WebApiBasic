using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiApplication.MyDBC;
using MyWebApiApplication.Models;
using MyWebApiApplication.DataDB;

namespace MyWebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private MyDBContext _context;

        public CategoryController(MyDBContext myDBContext)
        {
            _context = myDBContext;
        }

        [HttpGet]
        public IActionResult getAllCategory()
        {
            var listCategories = _context.categoies.ToList();
            return Ok(listCategories);
        }

        [HttpGet("id")]
        public IActionResult getCategoryById(int id)
        {
            var category = _context.categoies.SingleOrDefault(cate => cate.categoryId == id);

            if(category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult addCategory(CategoryModel cate)
        {
            try
            {
                var category = new Category
                {
                    categoryName = cate.categoryName
                };

                _context.Add(category);
                _context.SaveChanges();
                return Ok(cate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult updateCategory(int id, CategoryModel cateModel)
        {
                var category = _context.categoies.SingleOrDefault(cate => cate.categoryId == id);

                if (category != null)
                {
                category.categoryName = cateModel.categoryName;
                _context.SaveChanges();
                    return Ok(category);
                }
                else
                {
                    return NotFound();
                }
        }
    }
}
