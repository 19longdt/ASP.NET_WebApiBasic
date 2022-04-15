using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiApplication.Models;

namespace MyWebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> listProduct = new List<Product>();

        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(listProduct);
        }

        [HttpGet("{id}")]
        public IActionResult getProductById(string id)
        {
            try
            {
                var product = listProduct.SingleOrDefault(p => p.productID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }  
        }

        [HttpPost]
        public IActionResult createProduct(Product p)
        {
            var product = new Product {
                productID = Guid.NewGuid(),
                productName = p.productName,
                price = p.price
            };
            listProduct.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult updateProduct(string id, Product p)
        {
            try
            {
                var product = listProduct.SingleOrDefault(p => p.productID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }

                if(product.productID.ToString() != id)
                {
                    return BadRequest();
                }
                product.productName = p.productName;
                product.price = p.price;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteProduct(string id)
        {
            try
            {
                var product = listProduct.SingleOrDefault(p => p.productID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }

                listProduct.Remove(product);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
