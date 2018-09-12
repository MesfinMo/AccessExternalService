using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AES.Domains.WalmartApi;
using Newtonsoft.Json;

namespace AES.Data.DataSources
{
    public class WalmartOpenApi : IServiceContext
    {
        private const string BASE_API_URI = "http://api.walmartlabs.com/v1/";
        private const string API_KEY = "52txne3qyx4pnke2wxacsxff";

        public WalmartOpenApi()
        {

        }
        public async Task<ItemSearch> SearchItemByTextAsync(string searchText)
        {
            var _client = new HttpClient();
            ItemSearch itemSearch = null;
            var path = "search?apiKey=" + API_KEY + "&query=" + searchText;
            _client.BaseAddress = new Uri(BASE_API_URI);

            try
            {
                HttpResponseMessage response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var serializedItems = JsonConvert.DeserializeObject<ItemSearch>(result);
                    itemSearch = serializedItems != null ? serializedItems : throw new Exception("Results not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemSearch;
        }

        public async Task<List<Item>> GetItemByItemIdAsync(string itemId)
        {
            var _client = new HttpClient();
            List<Item> items = null;
            var path = "items?ids=" + itemId + "&apiKey=" + API_KEY;
            _client.BaseAddress = new Uri(BASE_API_URI);

            try
            {
                HttpResponseMessage response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var serializedItems = JsonConvert.DeserializeObject<Root>(result);
                    items =  serializedItems.items != null ?  serializedItems.items.ToList() : throw new Exception(result);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return items;
        }

        public async Task<List<ItemRecommendation>> GetItemRecommendationByItemIdAsync(string itemId)
        {
            var _client = new HttpClient();
            List<ItemRecommendation> itemRecommendation = null;
            var path = "nbp?apiKey=" + API_KEY + "&itemId=" + itemId;
            _client.BaseAddress = new Uri(BASE_API_URI);

            try
            {
                HttpResponseMessage response = await _client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    //JsonSerializerSettings settings = new JsonSerializerSettings();
                    //settings.MissingMemberHandling = MissingMemberHandling.Error;

                    var serializedItems = JsonConvert.DeserializeObject<List<ItemRecommendation>>(result);

                    itemRecommendation = serializedItems != null ? serializedItems : throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No recommendation is found for this product");
            }
            return itemRecommendation;
        }


    }
}
