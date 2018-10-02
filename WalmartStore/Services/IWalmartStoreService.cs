using AES.Domains.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartStore.Services
{
    public interface IWalmartStoreService
    {
        Task<SearchResult> SearchProductAsync(string searchTerm);
        Task<Product> GetProductByIdAsync(string productId);
        Task<List<Recommendation>> GetProductRecommendationsByIdAsync(string productId);
    }
}
