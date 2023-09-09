using AutoMapper;
using NLayer.Repository.Repository;
using NlayerCoreApp.DTOs;
using NlayerCoreApp.Models;
using NlayerCoreApp.Repositories;
using NlayerCoreApp.Service;
using NlayerCoreApp.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryrepository;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitofwork, IGenericRepository<Category> repository, IMapper mapper, ICategoryRepository categoryrepository) : base(unitofwork, repository)
        {
            _mapper = mapper;
            _categoryrepository = categoryrepository;
        }

        public async Task<CustomResponseDTO<CategoryWithProductsDTO>> GetCategoryByWithProductAsync(int categoryId)
        {
            var category = await _categoryrepository.GetCategoryByWithProductAsync(categoryId);
            var categoryDto=_mapper.Map<CategoryWithProductsDTO>(category);
            return CustomResponseDTO<CategoryWithProductsDTO>.Success(200, categoryDto);
        }
    }
}
