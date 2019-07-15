using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace awsomAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class rolesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get()
        {
        }

        [HttpPost]
        public void Post()
        {
        }

        [HttpPut("{id}")]
        public void Put()
        {
        }

        [HttpDelete("{id}")]
        public void Delete()
        {
        }
    }
}
