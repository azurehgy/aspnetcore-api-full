using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services
{
    public interface ICategoryService
    {
        //The implementations of the ListAsync method must asynchronously 
        //return an enumeration of categories.
        Task<IEnumerable<Category>> ListAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
        Task<SaveCategoryResponse> UpdateAsync(int id, Category category);
        Task<SaveCategoryResponse> DeleteAsync(int id);
    }
}
