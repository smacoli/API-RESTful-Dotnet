using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Models;
using Supermarket.Domain.Services;
using Supermarket.Extensions;
using Supermarket.Resources;

namespace Supermarket.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        #region GET
        // GET: Categories
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryResource>), 200)]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {            
            var categories = await _categoryService.ListAsync();
            return _mapper.Map<IEnumerable<CategoryResource>>(categories);
            
        }
        #endregion

        #region POST
        // POST: Categories
        [HttpPost]
        [ProducesResponseType(typeof(CategoryResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage);
            }

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if(!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Category,  CategoryResource>(result.Category);
            return Ok(categoryResource);
        }
        #endregion

        #region PUT
        // PUT: Categories
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage);
            }

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);
            
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if(!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);
        }
        #endregion
    }
}
