using Microsoft.EntityFrameworkCore;
using NlayerCoreApp.Models;
using NlayerCoreApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppdbContext appdbContext) : base(appdbContext)
        {
        }

        public async Task<Category> GetCategoryByWithProductAsync(int categoryId)
        {
            return await _appdbContext.Categories.Include(x => x.Products).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
