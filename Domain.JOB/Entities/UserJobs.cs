namespace Domain.JOB.Entities;

public class UserJobs : BaseEntity
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = default!;
    public Guid JobId { get; set; }
    public Job Job { get; set; } = default!;
}
