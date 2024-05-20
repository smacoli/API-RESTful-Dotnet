using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Supermarket.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<String> GetErrorMessage(this ModelStateDictionary modelStateDictionary) 
        {
            return modelStateDictionary.SelectMany(m => m.Value.Errors)
                .Select(m => m.ErrorMessage)
                .ToList();
        }
    }
}
