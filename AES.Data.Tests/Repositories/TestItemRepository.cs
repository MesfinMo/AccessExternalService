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
    public class TestItemRepository
    {
        IRepository<Item> itemRepository;

        [TestMethod]

        public async Task GetById_ShouldReturnProductForGivenId()
        {
            var items = new Item[]  {
                new Item { itemId= 12417832 }
            };
            var itemId = 12417832;

            var mock = new Mock<IServiceContext>();
            mock.Setup(m => m.GetItemByItemIdAsync(itemId)).Returns(Task.FromResult(items.ToList()));

            itemRepository = new ItemRepository(mock.Object);


            var result = await itemRepository.GetByIdAsync(itemId);

            Assert.AreEqual(result.itemId, itemId);
            mock.VerifyAll();

        }
    }
}
