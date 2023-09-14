using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NlayerCoreApp.DTOs;
using NlayerCoreApp.Models;
using NlayerCoreApp.Repositories;
using NlayerCoreApp.Service;
using NlayerCoreApp.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Cache
{
    public class ProductServiceWithCaching : IProductService
    {
        private const string CacheProductKey="ProductCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork; 
        public ProductServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;

            if (!_memoryCache.TryGetValue(CacheProductKey, out _))
            {
                _memoryCache.Set(CacheProductKey, _productRepository.GetProductWithCategory().Result);
            }
        }


        public async Task CacheAllProducts()
        {
            _memoryCache.Set(CacheProductKey, await _productRepository.GetAll().ToListAsync());
        }
        

        public async Task<Product> AddAsync(Product entity)
        {
            await _productRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
            return entity;
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _productRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Product entity)
        {
             _productRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
        }

        public async Task DeleteRangeAsync(IEnumerable<Product> entities)
        {
             _productRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Product>>(CacheProductKey));
        }

        public Task<Product> GetByIdAync(int id)
        {

            return Task.FromResult(_memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == id));
        }

        public Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductWithCategory()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Product entity)
        {
            _productRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProducts();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }
    }
}
