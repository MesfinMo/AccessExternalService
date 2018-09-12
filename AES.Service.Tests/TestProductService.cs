using AES.Data;
using AES.Data.Repositories;
using AES.Domains.Service;
using AES.Domains.WalmartApi;
using AES.Service.Mappings;
using AES.Service.Products;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Service.Tests
{
    [TestClass]
    public class TestProductService
    {
        IProductService productService;
        Mock<IRepository<Item>> itemmock;
        Mock<IRepository<ItemSearch>> searchmock;
        Mock<IRepository<ItemRecommendation>> recommndationmock;

        [TestInitialize]
        public void TestInitialize()
        {
            //Mapper.Reset();
            //Mapper.Initialize(x => x.AddProfile<MappingProfile>());

            var item = new Item { itemId = 12417832 };

            itemmock = new Mock<IRepository<Item>>();
            itemmock.Setup(m => m.GetByIdAsync(item.itemId)).Returns(Task.FromResult(item));

            var searchProduct = new ItemSearch { query = "ipod", items = new Item[] { new Item { itemId = 42608125 } } };
           

            searchmock = new Mock<IRepository<ItemSearch>>();
            searchmock.Setup(m => m.SearchByTextAsync(searchProduct.query)).Returns(Task.FromResult(searchProduct));

            var recommendations = new List<ItemRecommendation>() { new ItemRecommendation { itemId = 42608125, name = "Onn by Walmart skin for apple ipod touch", offerType = "ONLINE_AND_STORE" } };
            var recommendItemId = 12417832;

            recommndationmock = new Mock<IRepository<ItemRecommendation>>();
            recommndationmock.Setup(m => m.GetItemsByIdAsync(recommendItemId)).Returns(Task.FromResult(recommendations));
        }

        [TestMethod]

        public async Task SearchProductByText_ShouldReturnSearchResultForSearchText()
        {
            var searchText = "ipod";
            productService = new ProductService(itemmock.Object, searchmock.Object, recommndationmock.Object);

            var result = await productService.SearchProductByTextAsync(searchText);

            Assert.AreEqual(result.SearchTerm, searchText);
            Assert.AreEqual(result.Products[0].ProductId, 42608125);

        }
        [TestMethod]

        public async Task GetProductById_ShouldReturnProductForGivenId()
        {
            var productId = 12417832;
            productService = new ProductService(itemmock.Object, searchmock.Object, recommndationmock.Object);

            var result = await productService.GetProductByIdAsync(productId);

            Assert.AreEqual(result.ProductId, productId);

        }

        [TestMethod]

        public async Task GetProductRecommendationById_ShouldReturnRecommendationsForProduct()
        {
            var productId = 12417832;
            var OfferType = "ONLINE_AND_STORE";
            var productName = "Onn by Walmart skin for apple ipod touch";
            productService = new ProductService(itemmock.Object, searchmock.Object, recommndationmock.Object);

            var result = await productService.GetProductRecommendationByIdAsync(productId);

            Assert.IsTrue(result != null, "Should not return null");
            Assert.IsTrue(result.Count > 0, "Should return at least one recommendation");
            Assert.AreEqual(result[0].OfferType, OfferType);
            Assert.AreEqual(result[0].ProductName, productName);


        }
    }
}
