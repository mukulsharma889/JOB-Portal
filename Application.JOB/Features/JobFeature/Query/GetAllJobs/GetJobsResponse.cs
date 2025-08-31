using Shared.Enums;

namespace Application.JOB.Features.JobFeature.Query.GetAllJobs;

public class GetJobsResponse
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Location { get; set; } = default!;
    public decimal Salary { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string CompanyName { get; set; } = default!;
    public string CompanyWebsite { get; set; } = default!;
    public JobType JobType { get; set; }
}
