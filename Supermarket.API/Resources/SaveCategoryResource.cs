using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources
{
    /*This resource will map data that client applications 
     * send to this endpoint (in this case, the category name) 
     * to a class of our application.*/
    public class SaveCategoryResource
    {
        /*The ASP.NET Core pipeline uses this metadata to validate requests and responses.*/
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
