using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // BaseUrl/api/products
    public class ProductsController (IServiceManager _serviceManager) : ControllerBase
    {
        // Get All Products
        // GET: BaseUrl/api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTo>>> GetAllProducts() 
        {
            var products = await _serviceManager.ProductService.GetAllProductsAsync();
            return Ok(products);
        }
        // Get Product By Id
        // GET: BaseUrl/api/products/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTo> >GetProductById(int id)
        {
            var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
        // Get All Brands
        // GET: BaseUrl/api/products/brands
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDTo>>> GetAllBrands()
        {
            var brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }

        // Get All Types
        // GET: BaseUrl/api/products/types
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeDTo>>> GetAllTypes()
        {
            var types = await _serviceManager.ProductService.GetAllTypessAsync();
            return Ok(types);
        }

    }
}
