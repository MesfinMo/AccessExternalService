using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AES.Service.Products;
using Microsoft.AspNetCore.Mvc;
using WalmartStore.Models;

namespace WalmartStore.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
    }
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> SearchProduct(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var result = await _productService.SearchProductByTextAsync(searchTerm);
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
                result.Product = await _productService.GetProductByIdAsync(productId);
            }
            catch(Exception ex)
            {
                var err = new ErrorViewModel { ErrorMessage = ex.Message, ErrorLevel = ErrorLevel.Serious };
                return PartialView("_ErrorMessage", err);
            }
            try
            {
                result.Recommendations = await _productService.GetProductRecommendationByIdAsync(productId);
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                result.Recommendations = new List<AES.Domains.Service.Recommendation>();
            }
            //var model = _goalRepository.GetPayBandDimensionsByPayBandId(payBandId);
            return PartialView("_ProductDetail", result);
        }

    }
}
