using Application.JOB.Features.JobFeature.Command.AddEditJob;
using Application.JOB.Features.JobFeature.Query.GetAllJobs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JOB_Portal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobController(IMediator _mediator) : ControllerBase
{
    [HttpGet("get-jobs")]
    public async Task<IActionResult> GetJobs()
    {
        var result = await _mediator.Send(new GetJobsQuery());
        return Ok(result);
    }

    [HttpPost("add-edit-job")]
    public async Task<IActionResult> AddEditJob(AddEditJobCommand request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
