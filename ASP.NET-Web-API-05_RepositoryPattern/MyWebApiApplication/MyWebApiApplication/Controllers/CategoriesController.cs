using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApplication.DTO;
using MyWebApiApplication.Models;
using MyWebApiApplication.MyDBC;
using MyWebApiApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _cateRepo;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _cateRepo = categoryRepository;
        }

        [HttpGet]
        public IActionResult getAllCategory()
        {
            try
            {
                return Ok(_cateRepo.getAllCategory());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("id")]
        public IActionResult getCategoryById(int id)
        {
            var category = _cateRepo.getById(id);

            try
            {
                if (category != null)
                {
                    return Ok(category);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult addCategory(CategoryModel cate)
        {
            try
            {
                _cateRepo.addCategory(cate);
                return StatusCode(StatusCodes.Status201Created, cate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult updateCategory(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.categoryId)
            {
                return BadRequest();
            }
            try {
                _cateRepo.updateCategory(categoryDto);
                return NoContent();
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("id")]
        public IActionResult deteleCategory(int id)
        {
                _cateRepo.deleteCategory(id);
                return StatusCode(StatusCodes.Status200OK);
        }
    }
}
