using AES.Data.DataSources;
using AES.Data.Repositories;
using AES.Domains.WalmartApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Data.Tests.Repositories
{
    [TestClass]
    public class TestRecommendationRepository
    {
        IRepository<ItemRecommendation> recommendationRepository;

        [TestMethod]

        public async Task GetItemsById_ShouldReturnRecommendationsForItem()
        {
            var recommendations = new List<ItemRecommendation>() { new ItemRecommendation { itemId = 42608125, name = "Onn by Walmart skin for apple ipod touch", offerType = "ONLINE_AND_STORE" } };
            var recommendItemId = 12417832;

            var mock = new Mock<IServiceContext>();
            mock.Setup(m => m.GetItemRecommendationByItemIdAsync(recommendItemId)).Returns(Task.FromResult(recommendations));

            recommendationRepository = new RecommendationRepository(mock.Object);


            var result = await recommendationRepository.GetItemsByIdAsync(recommendItemId);

            Assert.AreEqual(result[0].itemId, 42608125);
            Assert.AreEqual(result[0].name, "Onn by Walmart skin for apple ipod touch");
            mock.VerifyAll();

        }
    }
}
