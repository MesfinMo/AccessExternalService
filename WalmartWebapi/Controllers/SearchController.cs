using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AES.Domains.Service;
using AES.Service.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WalmartWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductService _productService;
        public SearchController(IProductService productService)
        {
            this._productService = productService;
        }
        // GET: api/Search
        [Authorize(Policy = "WebUserReader")]
        [HttpGet("{query}", Name = "Get")]
        public async Task<ActionResult<SearchResult>> Get(string query)
        {
            var usr = User.Claims;
            return await _productService.SearchProductByTextAsync(query);
        }


        // POST: api/Search
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Search/5
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
