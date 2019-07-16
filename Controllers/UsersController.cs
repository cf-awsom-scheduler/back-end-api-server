using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using awsomAPI.Models;

namespace awsomAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AwsomApiContext _context;

        public RolesController(AwsomApiContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null) {
              return NotFound();
            }
            return user;
        }
        [HttpGet("test")]
        public string TestRoute()
        {
          return "success";
        }
    }
}
