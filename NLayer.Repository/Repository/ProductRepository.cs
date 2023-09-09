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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppdbContext appdbContext) : base(appdbContext)
        {
        }

        public async Task<List<Product>> GetProductWithCategory()
        {
            //Eager Loading
           return await _appdbContext.Products.Include(x=>x.Categorys).ToListAsync();
        }
    }
}
