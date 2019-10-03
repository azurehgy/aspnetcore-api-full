using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
        Task<Category> FindByIdAsync(int id);
        //Pay attention that the Update method isn’t asynchronous since the EF Core API 
        //does not require an asynchronous method to update models.
        void Update(Category category);
        void Remove(Category category);
    }
}
