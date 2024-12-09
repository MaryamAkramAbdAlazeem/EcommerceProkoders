using AutoMapper;
using EcommerceProkoders.Core.Contract.Repository;
using EcommerceProkoders.Core.Entities;
using EcommerceProkoders.DTOs.Products;
using EcommerceProkoders.Errors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EcommerceProkoders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository= productRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllAsync(int page, int pageSize)
        {

            var Products = await _productRepository.GetAllAsync(page, pageSize);

            return Ok(_mapper.Map<List<Product>, List<ProductDto>>((List<Product>)Products));
        }

        [HttpGet("GetProducts")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsAsync(string? modelNameFilter)
        {

            var Products = await _productRepository.GetProductsAsync(modelNameFilter);

            return Ok(_mapper.Map<List<Product>, List<ProductDto>>(Products));
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User",AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return NotFound(new ApiResponse(404));


            return Ok(_mapper.Map<Product, ProductDto>(product));
        }

        [HttpPost]
        [Authorize(Roles = "Admin",AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> PostProduct(CreateUpdateProductDto input)
        {
            var product = await _productRepository.AddAsync(_mapper.Map<CreateUpdateProductDto, Product>(input));

            return Ok(_mapper.Map<Product, ProductDto>(product));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProduct(int id, CreateUpdateProductDto input)
        {

            var temp = await _productRepository.GetByIdAsync(id);
            if (temp is null)
                return BadRequest(new ApiResponse(400));
            await _productRepository.UpdateAsync(_mapper.Map<CreateUpdateProductDto, Product>(input, temp));

            return Ok(_mapper.Map<Product, ProductDto>(await _productRepository.GetByIdAsync(id)));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteAsync(id);
            return NoContent();
        }

    }

}
