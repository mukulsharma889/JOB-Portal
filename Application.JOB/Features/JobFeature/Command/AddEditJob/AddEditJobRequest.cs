namespace Application.JOB.Features.JobFeature.Command.AddEditJob;

public class AddEditJobRequest
{
    public string Designation { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public List<string> MandatorySkills { get; set; } = [];
    public List<string> OptionalSkills { get; set; } = [];
}
