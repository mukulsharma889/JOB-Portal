using Shared.Enums;

namespace Domain.JOB.Entities;

public class Job : BaseEntity
{
    public string Designation { get; set; } = string.Empty;
    public string Description { get; set; } = default!;
    public Location Location { get; set; } = default!;
    public decimal Salary { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public Company CompanyName { get; set; } = default!;
    public string Highlights { get; set; } = default!;
    public List<string> MandatorySkills { get; set; } = [];
    public List<string> OptionalSkills { get; set; } = [];
    public JobType JobType { get; set; }
    public ICollection<UserJobs> UserJobs { get; set; } = [];
}
