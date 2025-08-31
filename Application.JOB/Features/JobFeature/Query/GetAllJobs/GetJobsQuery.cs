using Application.JOB.Modals.Common;
using MediatR;

namespace Application.JOB.Features.JobFeature.Query.GetAllJobs;

public class GetJobsQuery : IRequest<Result<GetJobsResponse>>
{
}
