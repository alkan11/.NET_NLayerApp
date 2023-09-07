using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Service.Services;
using NlayerCoreApp.DTOs;
using NlayerCoreApp.Models;
using NlayerCoreApp.Service;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductsController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products=await _service.GetAllAsync();
            var productsdto = _mapper.Map<List<ProductDTO>>(products.ToList());
            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productsdto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _service.GetByIdAync(id);
            var productsdto = _mapper.Map<ProductDTO>(products);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productsdto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO product)
        {
            var products = await _service.AddAsync(_mapper.Map<Product>(product));
            var productsdto = _mapper.Map<ProductDTO>(products);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsdto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO product)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(product));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product=await _service.GetByIdAync(id);
            await _service.DeleteAsync(product);
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }



    }
}
