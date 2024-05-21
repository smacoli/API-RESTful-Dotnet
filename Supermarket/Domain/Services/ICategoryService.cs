using Azure;
using Supermarket.Domain.Models;
using Supermarket.Domain.Services.Communication;

namespace Supermarket.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<ComResponse<Category>> SaveAsync(Category category);
        Task<ComResponse<Category>> UpdateAsync(int id, Category category);      
        Task<ComResponse<Category>> DeleteAsync(int id);
        
    }
}
