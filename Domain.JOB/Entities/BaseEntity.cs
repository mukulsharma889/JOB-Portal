namespace Domain.JOB.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public Guid CreatedBy { get; set; } = default!;
    public DateTime? ModifiedOn { get; set; }
    public Guid ModifiedBy { get; set; } = default!;
    public bool IsDeleted { get; set; }
}

