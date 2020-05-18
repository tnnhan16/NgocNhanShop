using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgocNhanShop.Business.Catelog.Category;
using NgocNhanShop.Business.Catelog.Category.Dtos;

namespace NgocNhanShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //// GET: api/Category
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var category = await _categoryService.GetAll();

        //    return Ok(category);
        //}

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery] CategoryPageRequest request)
        {
            var category = await _categoryService.GetAllPaging(request);

            return Ok(category);
        }

        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetByCategoryId(int CategoryId)
        {
            var category = await _categoryService.GetByCategoryId(CategoryId);
            if(category == null)
            {
                return BadRequest($"Cannot find category id {CategoryId}");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CategoryCreateRequest request)
        {
            var category = await _categoryService.CreateCategory(request);
            if (category.Id <= 0)
            {
                return BadRequest("Create category not success");
            }
            return CreatedAtAction(nameof(GetByCategoryId), new { CategoryId = category.Id }, category);
        }

        [HttpPut("{CategoryId}")]
        public async Task<IActionResult> Update(int CategoryId, [FromForm]CategoryUpdateRequest request)
        {
            var result = await _categoryService.UpdateCategory(CategoryId, request);
            if (result == 0)
            {
                return BadRequest("Update category not success");
            }
            return Ok();
        }

        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> Delete(int CategoryId)
        {
            var result = await _categoryService.DeleteCategory(CategoryId);
            if (result == 0)
            {
                return BadRequest("Delete category not success");
            }
            return Ok();
        }
    }
}
