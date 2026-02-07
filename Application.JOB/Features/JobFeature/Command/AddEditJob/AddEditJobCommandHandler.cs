using Application.JOB.Modals.Common;
using MediatR;

namespace Application.JOB.Features.JobFeature.Command.AddEditJob;

public class AddEditJobCommandHandler : IRequestHandler<AddEditJobCommand, Result<string>>
{
    public Task<Result<string>> Handle(AddEditJobCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
