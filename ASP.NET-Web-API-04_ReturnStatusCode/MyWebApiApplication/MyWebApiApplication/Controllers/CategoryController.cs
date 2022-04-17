using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiApplication.MyDBC;
using MyWebApiApplication.Models;
using MyWebApiApplication.DataDB;
using Microsoft.AspNetCore.Authorization;

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
            try
            {
                var listCategories = _context.categoies.ToList();
                return Ok(listCategories);
            }
            catch
            {
                return BadRequest();
            }
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
        //[Authorize]
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
                return StatusCode(StatusCodes.Status201Created, cate);
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

        [HttpDelete("id")]
        public IActionResult deteleCategory(int id)
        {
            var category = _context.categoies.SingleOrDefault(cate => cate.categoryId == id);

            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
