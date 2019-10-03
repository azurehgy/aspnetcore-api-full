using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*This class is just an abstract class that all our repositories will inherit. 
 * An abstract class is a class that don’t have direct instances. 
 * You have to create direct classes to create the instances.*/

/*The BaseRepository receives an instance of our AppDbContext through 
 * dependency injection and exposes a protected property 
 * (a property that can only be accessible by the children classes) called _context, 
 * that gives access to all methods we need to handle database operations.*/


namespace Supermarket.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
