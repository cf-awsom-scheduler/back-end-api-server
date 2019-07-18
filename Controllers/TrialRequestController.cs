///-------------------------------------------------------------------------------------------------
// file:	Controllers\TrialRequestController.cs
//
// summary:	Implements the trial request controller class.
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using awsomAPI.Models;


///-------------------------------------------------------------------------------------------------
// namespace: awsomAPI.Controllers
//
// summary:	Trial Request controller for working with trial requests.
///-------------------------------------------------------------------------------------------------

namespace awsomAPI.Controllers
{
    [Authorize]
    [Route("/trialRequests")]
    [ApiController]

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A controller for handling trial requests. </summary>
    ///
    /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class TrialRequestController : ControllerBase
    {
        private readonly AwsomApiContext _context;
        public TrialRequestController(AwsomApiContext context)
        {
            _context = context;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (An Action that handles HTTP GET requests) (Restricted to Roles = Role.Admin) gets trial
        ///     requests.
        /// </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <returns>   An asynchronous result that yields the trial requests. </returns>
        ///-------------------------------------------------------------------------------------------------

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrialRequest>>> GetTrialRequests()
        {
            return await _context.TrialRequests.ToListAsync();
        }

        // [Authorize(Roles = Role.Admin +","+ Role.User)]
        // [HttpGet("{region}")]
        // public async Task<ActionResult<IEnumerable<TrialRequest>>> GetByRegion(string region)
        // {
        //   return await _context.TrialRequests.Where(req => req.Region == region).ToListAsync();
        // }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (An Action that handles HTTP GET requests) (Restricted to Roles = Role.Admin + "," +
        ///     Role.User) trial request detail view.
        /// </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   An asynchronous result that yields an ActionResult&lt;TrialRequest&gt;. </returns>
        ///-------------------------------------------------------------------------------------------------

        [Authorize(Roles = Role.Admin + "," + Role.User)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TrialRequest>> TrialRequestDetailView(long id)
        {
            var trialRequest = await _context.TrialRequests.FindAsync(id);

            if (trialRequest == null)
            {
                return NotFound();
            }
            return trialRequest;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     (An Action that handles HTTP POST requests) (Restricted to Roles = Role.Admin + "," +
        ///     Role.User) select student.
        /// </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="selection">    The selection. </param>
        ///
        /// <returns>   An asynchronous result that yields an ActionResult. </returns>
        ///-------------------------------------------------------------------------------------------------

        [Authorize(Roles = Role.Admin + "," + Role.User)]
        [HttpPost("select")]
        public async Task<ActionResult> SelectStudent(StudentTeacherSelectedRelation selection)
        {
            _context.TeacherSelections.Add(selection);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        // [Authorize(Roles = Role.Admin)]
        // [HttpGet("selected")]
        // public async Task<ActionResult<IEnumerable<StudentTeacherSelectedRelation>>> GetSelected(string requestId)
        // {
        //   return await _context.TeacherSelections.Where( entry => entry.TrialRequestId == requestId ).ToListAsync();
        // }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   (An Action that handles HTTP POST requests) adds a new trial request. </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="trialRequest"> The trial request. </param>
        ///
        /// <returns>   An asynchronous result that yields an ActionResult&lt;TrialRequest&gt;. </returns>
        ///-------------------------------------------------------------------------------------------------

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<TrialRequest>> AddNewTrialRequest(TrialRequest trialRequest)
        {
            _context.TrialRequests.Add(trialRequest);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(TrialRequestDetailView), new { id = trialRequest.Id }, trialRequest);
        }
    }
}