using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NlayerCoreApp.Repositories;
using NlayerCoreApp.Service;

namespace NLayer.API.Controllers
{
    
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{categoryId}")]
        public  async Task<IActionResult> GetCategoryByWithProductAsync(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetCategoryByWithProductAsync(categoryId));
        }
    }
}
