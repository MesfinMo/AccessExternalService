using AES.Domains.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Service.Products
{
    public interface IProductService
    {
        Task<SearchResult> SearchProductByTextAsync(string searchText);
        Task<Product> GetProductByIdAsync(string productId);
        Task<List<Recommendation>> GetProductRecommendationByIdAsync(string productId);
    }
}
