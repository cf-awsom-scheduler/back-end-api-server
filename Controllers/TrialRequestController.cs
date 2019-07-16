using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using awsomAPI.Models;

namespace awsomAPI.Controllers
{
  [Route("/trialRequests")]
  [ApiController]

  public class TrialRequestController : ControllerBase
  {
        private readonly AwsomApiContext _context;
        public TrialRequestController(AwsomApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrialRequest>>> GetTrialRequests() 
        {
            return await _context.TrialRequests.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrialRequest>> TrialRequestDetailView(long id) 
        {
          var trialRequest = await _context.TrialRequests.FindAsync(id);

            if(trialRequest == null) {
              return NotFound();
            }
            return trialRequest;
        }

        [HttpPost]
        public async Task<ActionResult<TrialRequest>> AddNewTrialRequest(TrialRequest trialRequest)
        {
          _context.TrialRequests.Add(trialRequest);
          await _context.SaveChangesAsync();
          return CreatedAtAction(nameof(TrialRequestDetailView), new { id = trialRequest.Id }, trialRequest);
        }
  }
}