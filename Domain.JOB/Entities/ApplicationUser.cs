using Microsoft.AspNetCore.Identity;

namespace Domain.JOB.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public ICollection<Job> Jobs { get; set; } = [];
}
