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
            SearchResult productSearch = null;
            var result = await this._searchRepository.SearchByTextAsync(searchText);
            if (result != null && result.items != null)
            {
                var itemIds = string.Empty;
                foreach (var item in result.items)
                {
                    itemIds = itemIds + item.itemId + ",";
                }
                var items = await this._itemRepository.GetByIdAsync(itemIds.TrimEnd(','));

                productSearch = result.ToModel(); //AutoMapper.Mapper.Map<SearchResult>(result);

                if(productSearch != null && productSearch.SearchProducts != null)
                {
                    foreach(var product in productSearch.SearchProducts)
                    {
                        product.Product = items.Find(x => x.itemId == product.ProductId).ToModel();
                    }
                }
            }
            return productSearch;
        }
        public async Task<Product> GetProductByIdAsync(string productId)
        {
            var result = await this._itemRepository.GetByIdAsync(productId.ToString());
            var product = result[0].ToModel(); // AutoMapper.Mapper.Map<Product>(result);

            return product;
        }

        public async Task<List<Recommendation>> GetProductRecommendationByIdAsync(string productId)
        {
            List<Recommendation> recommendation = null;
            var result = await this._recommendationRepository.GetByIdAsync(productId);
            if (result != null)
            {
                result = result.Take(10).ToList();
                var itemIds = string.Empty;
                foreach (var item in result)
                {
                    itemIds = itemIds + item.itemId + ",";
                }
                var items = await this._itemRepository.GetByIdAsync(itemIds.TrimEnd(','));

                recommendation = result.ToListModel();// AutoMapper.Mapper.Map<List<Recommendation>>(result);

                if (recommendation != null)
                {
                    foreach (var recomm in recommendation)
                    {
                        recomm.Product = items.Find(x => x.itemId == recomm.ProductId).ToModel();
                    }
                }

               
            }
            return recommendation;
        }

       
    }
}
