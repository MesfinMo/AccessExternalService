using AES.Data.DataSources;
using AES.Domains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Data.Tests.WalmartApi
{
    [TestClass]
    public class TestWalmartOpenApi
    {
        IServiceContext walmartService;

        [TestMethod]
        public async Task SearchItemByText_ShouldReturnSearchResultForSearchText()
        {
            walmartService = new WalmartOpenApi();

            var searchText = "ipod";

            var result = await walmartService.SearchItemByTextAsync(searchText);

            Assert.AreEqual(result.query, searchText);

        }

        [TestMethod]
        public async Task GetItemByItemId_ShouldReturnItemForGivenItemId()
        {
            walmartService = new WalmartOpenApi();

            var itemId = "12417832";

            var result = await walmartService.GetItemByItemIdAsync(itemId);

            Assert.AreEqual(result[0].itemId, itemId);
            
        }

        [TestMethod]
        public async Task GetItemRecommendationByItemId_ShouldReturnRecommendationsForGivenItemId()
        {
            walmartService = new WalmartOpenApi();

            var itemId = "42608125";

            var result = await walmartService.GetItemRecommendationByItemIdAsync(itemId);

            Assert.IsTrue(result != null, "Should not return null");
            Assert.IsTrue(result.Count > 0, "Should return at least one recommendation");

        }
    }
}
