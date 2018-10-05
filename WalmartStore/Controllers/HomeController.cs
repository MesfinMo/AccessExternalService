using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AES.Service.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalmartStore.Models;
using WalmartStore.Services;

namespace WalmartStore.Controllers
{
    public class HomeController : Controller
    {
        private IWalmartStoreService _walmartStoreService;

        public HomeController(IWalmartStoreService walmartStoreService)
        {
            _walmartStoreService = walmartStoreService;
        }
       // [Authorize]
        public IActionResult Index()
        {
            //var result = await _productService.SearchProductByTextAsync("ipod");
            return View();

        }
       
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {

            return Created("url", "test"); // View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> SearchProduct(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var result = await _walmartStoreService.SearchProductAsync(searchTerm);
                return PartialView("_SearchResult", result);
            } else
            {
                var result = new ErrorViewModel { ErrorMessage = "Please enter search term, and try again", ErrorLevel = ErrorLevel.Serious };
                return PartialView("_ErrorMessage", result);
            }
           
        }

        public async Task<IActionResult> ProductDetail(string productId)
        {
            var result = new ProductDetailViewModel();
            try
            {
                result.Product = await _walmartStoreService.GetProductByIdAsync(productId);
            }
            catch(Exception ex)
            {
                var err = new ErrorViewModel { ErrorMessage = ex.Message, ErrorLevel = ErrorLevel.Serious };
                return PartialView("_ErrorMessage", err);
            }
            try
            {
                result.Recommendations = await _walmartStoreService.GetProductRecommendationsByIdAsync(productId);
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                result.Recommendations = new List<AES.Domains.Service.Recommendation>();
            }
            return PartialView("_ProductDetail", result);
        }

    }
}
