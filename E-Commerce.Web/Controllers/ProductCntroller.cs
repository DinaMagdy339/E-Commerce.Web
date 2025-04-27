using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DataTransferObjects;

namespace E_Commerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCntroller(IServiceManager _ServiceManager) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDTo>>> GetAllProducts([FromQuery]ProductQueryParams queryParams)
        {
            var products = await _ServiceManager.ProductService.GetAllProductsAsync(queryParams);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTo>> GetProduct(int id)
        {
            var product = await _ServiceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDTo>>> GetAllBrands()
        {
            var brands = await _ServiceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeDTo>>> GetAllTypes()
        {
            var types = await _ServiceManager.ProductService.GetAllTypessAsync();
            return Ok(types);
        }
    }
}
