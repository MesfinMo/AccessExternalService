using AES.Domains.WalmartApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Data.DataSources
{
    public interface IServiceContext
    {
        Task<ItemSearch> SearchItemByTextAsync(string  searchText);
        Task<List<Item>> GetItemByItemIdAsync(int itemId);

        Task<List<ItemRecommendation>> GetItemRecommendationByItemIdAsync(int itemId);
    }
}
