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

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrialRequest>> TrialRequestDetailView() 
        {
          
        }

        [HttpPost]
        public async Task<ActionResult<TrialRequest>> AddNewTrialRequest()
        {
          
        }
  }
}