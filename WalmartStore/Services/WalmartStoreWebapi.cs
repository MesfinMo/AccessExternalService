using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AES.Domains.Service;
using Newtonsoft.Json;

namespace WalmartStore.Services
{
    public class WalmartStoreWebapi : IWalmartStoreService
    {
        //TODO: Get Uris from configuration
        //private const string BASE_API_URI = "http://localhost:5000/api/";
        private const string BASE_API_URI = "http://walmartwebapi-dev.us-east-1.elasticbeanstalk.com/api/";

        //private const string API_KEY = "52txne3qyx4pnke2wxacsxff";

        private ITokenService _tokenService;
        public WalmartStoreWebapi(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public async Task<Product> GetProductByIdAsync(string productId)
        {
            var _client = new HttpClient();
            Product product = null;
            var path = "products/" + productId;
            _client.BaseAddress = new Uri(BASE_API_URI);
            var token = await _tokenService.GetTokenAsync();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    product = JsonConvert.DeserializeObject<Product>(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }

        public async Task<List<Recommendation>> GetProductRecommendationsByIdAsync(string productId)
        {
            var _client = new HttpClient();
            List<Recommendation> productRecommendations = null;
            var path = "products/" + productId + "/recommendations";
            _client.BaseAddress = new Uri(BASE_API_URI);
            var token = await _tokenService.GetTokenAsync();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var serializedRecommendations = JsonConvert.DeserializeObject<List<Recommendation>>(result);

                    productRecommendations = serializedRecommendations != null ? serializedRecommendations : throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No recommendation is found for this product");
            }
            return productRecommendations;
        }

        public async Task<SearchResult> SearchProductAsync(string searchTerm)
        {
            var _client = new HttpClient();
            SearchResult productSearch = null;
            var path = "search/" + searchTerm;
            _client.BaseAddress = new Uri(BASE_API_URI);
            var token = await _tokenService.GetTokenAsync();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                HttpResponseMessage response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var serializedResult = JsonConvert.DeserializeObject<SearchResult>(result);
                    productSearch = serializedResult != null ? serializedResult : throw new Exception("Results not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productSearch;
        }
    }
}
