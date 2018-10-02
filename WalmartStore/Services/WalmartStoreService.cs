using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AES.Domains.Service;
using AES.Service.Products;

namespace WalmartStore.Services
{
    public class WalmartStoreService : IWalmartStoreService
    {
        private IProductService _productService;

        public WalmartStoreService(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Product> GetProductByIdAsync(string productId)
        {
            return await _productService.GetProductByIdAsync(productId);
        }

        public async Task<List<Recommendation>> GetProductRecommendationsByIdAsync(string productId)
        {
            return await _productService.GetProductRecommendationByIdAsync(productId);
        }

        public async Task<SearchResult> SearchProductAsync(string searchTerm)
        {
            return await _productService.SearchProductByTextAsync(searchTerm);
        }
    }
}
