using APIs.Data;
using APIs.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIs.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // domain.com/api/Users
    public class UsersController : ControllerBase
    {
        //there is always constructor inside controller to initial and prepare some of the data or function ready to use
        // code dependency injection concept apply here
        // in order to inject something into a class we need to provide a class with a constructor (true) or say first line of this comment

        //shortcut typr ctor + tab
        // when user hits this api it create not only the instance of this class but also instance of Datacontext, this means that we have available season with our database
         
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            this._context = context;

        }

        // syncronous api
        /*
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var Users = _context.Users.ToList();
            return Users;
        }
        */
        //Async Api
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var Users = await _context.Users.ToListAsync();
            //ToListAsync method is from entity framwork
            return Users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //return _context.Users.FirstOrDefault(x => x.Id == id);
            //return _context.Users.Find(id);
            var user = await _context.Users.FindAsync(id);
            return user;
        }
        /*
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            //return _context.Users.FirstOrDefault(x => x.Id == id);
            //return _context.Users.Find(id);
            var user = _context.Users.Find(id);
            return user;
        }
        */
    }
}
