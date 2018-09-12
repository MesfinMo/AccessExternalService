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
        public async Task<IActionResult> Index()
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
            var result = await _productService.SearchProductByTextAsync(searchTerm);
            //var model = _goalRepository.GetPayBandDimensionsByPayBandId(payBandId);
            return PartialView("_SearchResult", result);
        }

    }
}
