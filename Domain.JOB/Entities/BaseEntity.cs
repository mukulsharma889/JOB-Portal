namespace Domain.JOB.Entities;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; } = default!;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public TKey CreatedBy { get; set; } = default!;
    public DateTime? ModifiedOn { get; set; }
    public TKey ModifiedBy { get; set; } = default!;
    public bool IsDeleted { get; set; }
}

