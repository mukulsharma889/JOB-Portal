using Application.JOB.Modals.Common;
using MediatR;

namespace Application.JOB.Features.JobFeature.Command.AddEditJob;

public class AddEditJobCommand : IRequest<Result<string>>
{
}
