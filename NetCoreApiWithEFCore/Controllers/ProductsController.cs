using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Data;
using Module1.Models;
using Module1.Services;

namespace Module1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProduct productRepository;
        public ProductsController(IProduct _product)
        {
            productRepository = _product;
        }
        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get(string searchProduct)
        {
            return productRepository.GetProducts(searchProduct);
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound("No record found..");
            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productRepository.AddProduct(product);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            productRepository.UpdateProduct(product);

            return Ok("Product updated successfully");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id);
            return Ok("Product deleted");
        }
    }
}
