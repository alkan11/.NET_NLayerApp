using NlayerCoreApp.DTOs;
using NlayerCoreApp.Models;
using NlayerCoreApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerCoreApp.Service
{
    public interface ICategoryService:IService<Category>   
    {
        Task<CustomResponseDTO<CategoryWithProductsDTO>> GetCategoryByWithProductAsync(int category);
    }
}
