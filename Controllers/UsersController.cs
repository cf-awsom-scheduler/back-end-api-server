using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using awsomAPI.Models;

namespace awsomAPI.Controllers
{
    [Route("/users")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly AwsomApiContext _context;

        public RolesController(AwsomApiContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            users.ForEach( entry => entry.Password = null);
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null) {
              return NotFound();
            }
            if(user != null) {
              user.Password = null;
            }

            // var currentUserId = int.Parse(User.Identity.Name);
            // if (id != currentUserId && !User.IsInRole(Role.Admin)) {
            //   return Forbid();
            // }
            // return user;
        }
        [HttpPost("signin")]
        [AllowAnonymous]
        public Task<ActionResult> signin()
        {

        }
    }
}

/*
        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }
 */