using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AES.Data;
using AES.Data.Repositories;
using AES.Domains.Service;
using AES.Domains.WalmartApi;
using AES.Service.Mappings;

namespace AES.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<ItemSearch> _searchRepository;
        private readonly IRepository<ItemRecommendation> _recommendationRepository;

        public ProductService(IRepository<Item> itemRepository, IRepository<ItemSearch> searchRepository, IRepository<ItemRecommendation> recommendationRepository)
        {
            _itemRepository = itemRepository;
            _searchRepository = searchRepository;
            _recommendationRepository = recommendationRepository;
        }
        public async Task<SearchResult> SearchProductByTextAsync(string searchText)
        {
            var result = await this._searchRepository.SearchByTextAsync(searchText);
            var productSearch = result.ToModel(); //AutoMapper.Mapper.Map<SearchResult>(result);

            return productSearch;
        }
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var result = await this._itemRepository.GetByIdAsync(productId);
            var product = result.ToModel(); // AutoMapper.Mapper.Map<Product>(result);

            return product;
        }

        public async Task<List<Recommendation>> GetProductRecommendationByIdAsync(int productId)
        {
            var result = await this._recommendationRepository.GetItemsByIdAsync(productId);
            var recommendation = result.ToListModel();// AutoMapper.Mapper.Map<List<Recommendation>>(result);

            return recommendation;
        }

       
    }
}
