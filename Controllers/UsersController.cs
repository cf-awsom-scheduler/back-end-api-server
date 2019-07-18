///-------------------------------------------------------------------------------------------------
// file:	Controllers\UsersController.cs
//
// summary:	Implements the users controller class.
///-------------------------------------------------------------------------------------------------

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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using awsomAPI.Models;

//Morgana - JWT Auth Functionality found here https://jasonwatmore.com/post/2019/01/08/aspnet-core-22-role-based-authorization-tutorial-with-example-api#app-settings-json

namespace awsomAPI.Controllers
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary> A controller for handling users. </summary>
    ///
    /// <remarks> Vanvoljg, 18-Jul-19. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [Authorize]
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly AwsomApiContext _context;
        public IConfiguration Configuration { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="context">          The context. </param>
        /// <param name="configuration">    The configuration. </param>
        ///-------------------------------------------------------------------------------------------------

        public UsersController(AwsomApiContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (An Action that handles HTTP GET requests) (Restricted to Roles = Role.Admin) gets the
        ///     users.
        /// </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <returns>   An asynchronous result that yields all the users. </returns>
        ///-------------------------------------------------------------------------------------------------

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            users.ForEach(entry => entry.Password = null);
            return users;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (An Action that handles HTTP GET requests) gets a user. </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   An asynchronous result that yields the user. </returns>
        ///-------------------------------------------------------------------------------------------------

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

            int currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }
            return user;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (An Action that handles HTTP POST requests) signins the given user from frontend.
        /// </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="userFromFrontend"> The user from frontend. </param>
        ///
        /// <returns>   An asynchronous result that yields an ActionResult&lt;User&gt;. </returns>
        ///-------------------------------------------------------------------------------------------------

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Signin([FromBody]User userFromFrontend)
        {
            string email = userFromFrontend.Email;
            string password = userFromFrontend.Password;
            User user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user == null)
            {
                return NotFound();
            }
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(Configuration["Secret"]);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (An Action that handles HTTP POST requests) adds a user. </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="user"> The user. </param>
        ///
        /// <returns>   An asynchronous result that yields an ActionResult&lt;User&gt;. </returns>
        ///-------------------------------------------------------------------------------------------------

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            Regex awsomEmail = new Regex(@"@awsom\.info$");

            if (!awsomEmail.IsMatch(user.Email.ToLower()))
            {
                return Forbid();
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
    }
}
