using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using awsomAPI.Models;

namespace awsomAPI.Controllers
{
  [Authorize]
  [Route("/trialRequests")]
  [ApiController]

  public class TrialRequestController : ControllerBase
  {
    private readonly AwsomApiContext _context;
    public TrialRequestController(AwsomApiContext context)
    {
      _context = context;
    }

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

    [Authorize(Roles = Role.Admin +","+ Role.User)]
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

    [Authorize(Roles = Role.Admin +","+ Role.User)]
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