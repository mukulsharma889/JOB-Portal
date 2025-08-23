using Shared.Enums;

namespace Domain.JOB.Entities;

public class Job : BaseEntity<Guid>
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Location { get; set; } = default!;
    public decimal Salary { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string CompanyName { get; set; } = default!;
    public string CompanyWebsite { get; set; } = default!;
    public JobType JobType { get; set; }
    public ICollection<UserJobs> UserJobs { get; set; } = [];
}
