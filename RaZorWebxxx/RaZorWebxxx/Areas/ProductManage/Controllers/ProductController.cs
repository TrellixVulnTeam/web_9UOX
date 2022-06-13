using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RaZorWebxxx.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaZorWebxxx.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ProductServices _productServices;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductServices productServices, ILogger<ProductController> logger)
        {
            _productServices = productServices;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = _productServices.OrderBy(p => p.Name).ToList();
            return View(products);
        }
    }
}
