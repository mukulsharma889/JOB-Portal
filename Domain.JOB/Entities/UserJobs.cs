namespace Domain.JOB.Entities;

public class UserJobs : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = new();
    public Guid JobId { get; set; }
    public Job Job { get; set; } = new();
}
