using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductsController(IProductRepository repository)
        {
            _productRepo = repository;
        }

        [HttpGet("{txtSearch}")]
        public IActionResult searchProduct(string txtSearch, double? priceFrom, double? priceTo, int? sortBy, int page)
        {
            try
            {
                var result = _productRepo.searchProduct(txtSearch, priceFrom, priceTo, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't load result...");
            }
        }

        [HttpGet]
        public IActionResult getAllProduct()
        {
            try
            {
                var result = _productRepo.getAllProduct();
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't load result...");
            }
        }
    }
}
