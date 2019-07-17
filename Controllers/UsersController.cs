using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using awsomAPI.Models;

//Morgana - JWT Auth Functionality found here https://jasonwatmore.com/post/2019/01/08/aspnet-core-22-role-based-authorization-tutorial-with-example-api#app-settings-json

namespace awsomAPI.Controllers
{
  [Authorize]
  [ApiController]
  [Route("/users")]
  public class RolesController : ControllerBase
  {
    private readonly AwsomApiContext _context;
    public IConfiguration Configuration { get; set; }

    public RolesController(AwsomApiContext context, IConfiguration configuration)
    {
      _context = context;
      Configuration = configuration;
    }

    [HttpGet]
    [Authorize(Roles = Role.Admin)]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
      List<User> users = await _context.Users.ToListAsync();
      users.ForEach(entry => entry.Password = null);
      return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(long id)
    {
      var user = await _context.Users.FindAsync(id);

      if (user == null)
      {
        return NotFound();
      }
      if (user != null)
      {
        user.Password = null;
      }

      var currentUserId = int.Parse(User.Identity.Name);
      if (id != currentUserId && !User.IsInRole(Role.Admin))
      {
        return Forbid();
      }
      return user;
    }
    [HttpPost("signin")]
    [AllowAnonymous]
    public async Task<ActionResult<User>> signin([FromBody]User userFromFrontend)
    {
      string email = userFromFrontend.Email;
      string password = userFromFrontend.Password;
      var user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

      if (user == null)
      {
        return NotFound();
      }
      JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(Configuration["Secret"]);
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
    [HttpPost("signup")]
    [AllowAnonymous]
    public async Task<ActionResult<User>> addUser(User user)
    {
      {
        if(user.Code == null || user.Code.Equals(Configuration["Code"])) {
          return Forbid();
        }
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
      }
    }
  }
}
