using Supermarket.Domain.Models;
using Supermarket.Domain.Services;
using Supermarket.Domain.Repositories;
using Supermarket.Domain.Services.Communication;
using Microsoft.Extensions.Caching.Memory;
using Supermarket.Infra;

namespace Supermarket.Service 
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService
            (
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            IMemoryCache cache,
            ILogger<CategoryService> logger
            ) 
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            var categories = await _cache.GetOrCreateAsync(CacheKeys.CategoriesList, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _categoryRepository.ListAsync();
            });

            return categories ?? new List<Category>();
        }

        public async Task<ComResponse<Category>> SaveAsync(Category category) 
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new ComResponse<Category>(category);
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "Could not save category.");
                return new ComResponse<Category>($"An error occurred when saving the category: {ex.Message}");
                
            }
        }
        
        public async Task<ComResponse<Category>> UpdateAsync(int id, Category category) 
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
            {
                return new ComResponse<Category>("Category not found");
            }

            existingCategory.Name = category.Name;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new ComResponse<Category>(existingCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not update the category: {id}.", id);
                return new ComResponse<Category>($"An error occurred: {ex.Message}");
            }
        }
        
        public async Task<ComResponse<Category>> DeleteAsync(int id) 
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if(existingCategory == null)
            {
                return new ComResponse<Category>("Category not found.");
            }

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ComResponse<Category>(existingCategory);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Could not remove the category: {id}", id);
                return new ComResponse<Category>($"An error occurred when deleting the category: {ex.Message}");
            }
        }
        
    }
}
