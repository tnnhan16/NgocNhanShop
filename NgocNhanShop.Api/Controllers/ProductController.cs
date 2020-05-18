using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgocNhanShop.Business.Catelog.Prodcuts;
using NgocNhanShop.Business.Catelog.Prodcuts.Dtos;

namespace NgocNhanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //// GET: api/Product
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var product = await _productService.GetAll();

        //    return Ok(product);
        //}

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery] ProductPageRequest request)
        {
            var product = await _productService.GetAllPaging(request);

            return Ok(product);
        }

        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetByProductId(int ProductId)
        {
            var product = await _productService.GetByProductId(ProductId);
            if(product == null)
            {
                return BadRequest($"Cannot find product id {ProductId}");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            var product = await _productService.CreateProduct(request);
            if (product.Id <= 0)
            {
                return BadRequest("Create product not success");
            }
            return CreatedAtAction(nameof(GetByProductId), new { ProductId = product.Id }, product);
        }

        [HttpPut("{ProductId}")]
        public async Task<IActionResult> Update(int ProductId, [FromForm]ProductUpdateRequest request)
        {
            var result = await _productService.UpdateProduct(ProductId, request);
            if (result == 0)
            {
                return BadRequest("Update product not success");
            }
            return Ok();
        }

        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> Delete(int ProductId)
        {
            var result = await _productService.DeleteProduct(ProductId);
            if (result == 0)
            {
                return BadRequest("Delete product not success");
            }
            return Ok();
        }
    }
}
