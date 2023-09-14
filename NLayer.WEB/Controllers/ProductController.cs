using Microsoft.AspNetCore.Mvc;
using NlayerCoreApp.Service;

namespace NLayer.WEB.Controllers
{
    public class ProductController:Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var customResponse=await _productService.GetProductWithCategory();
            return View(customResponse.Data);
        }
    }
}
