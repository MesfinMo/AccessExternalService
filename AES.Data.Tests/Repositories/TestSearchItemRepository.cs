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
    public class TestSearchItemRepository
    {
        IRepository<ItemSearch> searchRepository;

        [TestMethod]

        public async Task SearchByText_ShouldReturnSearchResultForSearchTex()
        {
            var searchItem = new ItemSearch { query = "ipod", items = new Item[] { new Item { itemId = "42608125" } } };
            
            var searchText = "ipod";

            var mock = new Mock<IServiceContext>();
            mock.Setup(m => m.SearchItemByTextAsync(searchText)).Returns(Task.FromResult(searchItem));

            searchRepository = new SearchRepository(mock.Object);


            var result = await searchRepository.SearchByTextAsync(searchText);

            Assert.AreEqual(result.query, searchText);
            mock.VerifyAll();

        }
    }
}
