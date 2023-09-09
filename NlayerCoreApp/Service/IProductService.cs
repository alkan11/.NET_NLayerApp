using NlayerCoreApp.DTOs;
using NlayerCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerCoreApp.Service
{
    public interface IProductService:IService<Product>
    {
        Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductWithCategory();
    }
}
