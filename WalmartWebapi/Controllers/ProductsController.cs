using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AES.Domains.Service;
using AES.Service.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WalmartWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }
        // GET: api/Products
        [HttpGet]
        public void Get()
        {
        }

        // GET: api/Products/49053771
        [HttpGet("{productId}", Name = "GetProduct")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> Get(string productId)
        {
            if(string.IsNullOrEmpty(productId))
            {
                return BadRequest(productId);
            }

            var result = await _productService.GetProductByIdAsync(productId);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // GET: api/Products/49053771/Recommendations
        [HttpGet("{productId}/recommendations", Name = "GetProductRecommendations")]
        public async Task<ActionResult<List<Recommendation>>> GetProductRecommendations(string productId)
        {
            return await _productService.GetProductRecommendationByIdAsync(productId);
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
