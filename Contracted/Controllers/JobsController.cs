using System;
using Contracted.Models;
using Contracted.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _js;

        public JobsController(JobsService js)
        {
            _js = js;
        }

        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job job)
        {
            try
            {
                Job newJob = _js.Create(job);
                return Ok(newJob);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Job> Delete(int id)
        {
            try
            {
                _js.Delete(id);
                return Ok("DELETED");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}