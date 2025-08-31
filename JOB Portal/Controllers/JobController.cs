using Application.JOB.Features.JobFeature.Query.GetAllJobs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JOB_Portal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetJobs()
    {
        var result = await _mediator.Send(new GetJobsQuery());
        return Ok("Got all jobs");
    }
}
