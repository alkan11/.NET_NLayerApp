using AutoMapper;
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
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitofwork, IGenericRepository<Product> repository, IProductRepository productRepository, IMapper mapper) : base(unitofwork, repository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductWithCategory()
        {
           var product=await _productRepository.GetProductWithCategory();
            var productsdto=_mapper.Map<List<ProductWithCategoryDTO>>(product);
            return CustomResponseDTO<List<ProductWithCategoryDTO>>.Success(200, productsdto);
        }
    }
}
