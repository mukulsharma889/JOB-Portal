using Application.JOB.Interfaces;
using Application.JOB.Modals.Common;
using Domain.JOB.Entities;
using MediatR;

namespace Application.JOB.Features.JobFeature.Query.GetAllJobs;

public class GetJobsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetJobsQuery, Result<GetJobsResponse>>
{
    public async Task<Result<GetJobsResponse>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Job> result = _unitOfWork.Repository<Job>().Entities.AsQueryable();
        return await Result<GetJobsResponse>.SuccessAsync();
    }
}
