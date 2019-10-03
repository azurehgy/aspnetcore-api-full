using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers
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


        //[HttpGet]
        //public async Task<IEnumerable<Category>> GetAllAsync()
        //{
        //    // The framework pipeline handles the serialization of data to a JSON object. 
        //    var categories = await _categoryService.ListAsync();
        //    return categories;
        //}
        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            // The framework pipeline handles the serialization of data to a JSON object. 
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            return resources;
        }

        [HttpPost]
        /*The FromBody attribute tells ASP.NET Core to parse the request body 
         * data into our new resource class. It means that when a 
         * JSON containing the category name is sent to our application, 
         * the framework will automatically parse it to our new class.*/

        /*First, we have to validate the incoming request.If the request is invalid, 
         * we have to return a bad request response containing the error messages;
         * 
        Then, if the request is valid, we have to map our new resource to 
        our category model class using AutoMapper;

        We now need to call our service, telling it to save our new category.
        If the saving logic is executed without problems, 
        it should return a response containing our new category data.
        If not, it should give us an indication that the process failed, 
        and a potential error message;

        Finally, if there is an error, we return a bad request.
        If not, we map our new category model to a category resource 
        and return a success response to the client, containing the new category data.*/
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }
    }
}
