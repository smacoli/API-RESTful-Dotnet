using Supermarket.Domain.Models;

namespace Supermarket.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        /// <summary>
        /// Propriedade Category salvará os dados de uma categoria caso a requisição seja bem sucedida 
        /// </summary>
       
        public Category Category { get; private set; }

        private CategoryResponse(bool success, string message, Category category) : base(success, message) 
        {
            Category = category;
        }

        public CategoryResponse(Category category) : this(true, string.Empty, category) { }

        public CategoryResponse(string message) : this(false, message, null) { }
    }
}
