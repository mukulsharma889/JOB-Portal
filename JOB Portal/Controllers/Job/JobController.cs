using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JOB_Portal.Controllers.Job;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    [HttpGet]
    public IActionResult GetJobs()
    {
        return Ok("Got all jobs");
    }
}
